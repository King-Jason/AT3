using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MediaInfoDotNet; //https://github.com/Nicholi/MediaInfoDotNet
using MediaInfoLib; //https://github.com/Nicholi/MediaInfoDotNet

namespace MusicPlayer
{
    //Jason King
    //P465642
    //12/12/2019
    //This is a music player program which is synced to a database to save the user details and songs. It allows you to play, pause, skip and go back songs.
    public partial class MusicPlayer : Form
    {
        private DBC dbc = new DBC();
        private Session session = new Session();
        private LinkedList<Song> musicList = new LinkedList<Song>();
        private int counter = 0;
        private Song currentsong;
        private Song selectedSong;
        public MusicPlayer()
        {
            //dbc.EncryptString();
            dbc.DecryptString();
            InitializeComponent();
        }

        /*
         * Gets the login details from the textboxes and hashes the 
         * password to see if it matches the one stored in the database
         */
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (dbc.login(tbUsername.Text, tbPassword.Text))
            {
                session.newSession(dbc.getEmailFromAccount(tbUsername.Text), tbUsername.Text, tbPassword.Text, dbc.getUserID(tbUsername.Text));
                session.loggedIn = true;
                tbUsername.Clear();
                tbPassword.Clear();
                if (session.loggedIn)
                {
                    Console.WriteLine("Logged In");
                    loginPanel.Visible = false;
                    initialiseClient();
                }
            }
            else
            {
                MessageBox.Show("Incorrect username or password.");
            }
        }
        /*
         * Once the user has succesfullly loged in it runs 
         * the initialise client method which changes the panels 
         * over and gets all the songs and check which ones 
         * stil exists etc.
         */
        public void initialiseClient()
        {
            lblProfileName.Text = "Welcome " + session.username;
            musicPanel.Visible = true;
            getSongs();
            checkIfSongExists();
            getSongs();
            WMP.settings.volume = 25;
            hSBVolume.Value = 25;
        }
        /*
         * Opens the open file dialog and allows you to select 
         * one or multiple songs and have them added to the 
         * database and the linked list then diplayed.
         */
        private void btnAddSong_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog() { Multiselect = true, ValidateNames = true })
                {
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        foreach (string fileName in openFileDialog.FileNames)
                        {
                            MediaInfo MI = new MediaInfo();
                            MI.Open(fileName);
                            Song song = new Song();
                            song.userID = session.userID;
                            song.songName = MI.Get(StreamKind.General, 0, "Title");
                            song.artistName = MI.Get(StreamKind.General, 0, "Performer");
                            song.songPath = fileName;
                            MI.Close();
                            musicList.AddLast(song);
                            dbc.addSongToDB(song.userID, song.songName, song.artistName, song.songPath);
                        }
                    }
                }
                displaySongs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to add song or songs \n\n Reported Error: " + ex);
            }
        }
        /*
         * Go through each song in the linkedlist to display 
         * the song file name without the path.
         */
        public void displaySongs()
        {
            lbSongs.Items.Clear();
            foreach (Song song in musicList)
            {
                string file = Path.GetFileNameWithoutExtension(song.songPath);
                lbSongs.Items.Add(file);
            }
        }
        /*
         * Gets the songs from the database depending on which user.
         */ 
        public void getSongs()
        {
            musicList = dbc.getUsersSongs(session.userID);
            displaySongs();
        }

        /*
         * Allows you to play songs depending on which is selected in the list.
         *If a song is currently playing than it will change to a pause button and allows you to pause it.
         * 
         */ 
        private void btnPlay_Click(object sender, EventArgs e)
        {
            try
            {
                if(btnPlay.Text == "Play")
                {
                    if (lbSongs.SelectedIndex == 0)
                    {
                        WMP.URL = musicList.First().songPath;
                        currentsong = musicList.First();
                        counter = 0;
                        if (string.IsNullOrWhiteSpace(musicList.First().songName))
                        {
                            lblSongName.Text = Path.GetFileNameWithoutExtension(musicList.First().songPath);
                        }
                        else
                        {
                            lblSongName.Text = Path.GetFileNameWithoutExtension(musicList.First().songName);
                        }
                    }
                    else
                    {
                        Song searchSong = musicList.First();
                        for (int i = 0; i < musicList.Count - 1; i++)
                        {
                            LinkedListNode<Song> temp = musicList.Find(searchSong).Next;
                            if (Path.GetFileNameWithoutExtension(temp.Value.songPath).Contains(lbSongs.SelectedItem.ToString()))
                            {
                                counter = i + 1;
                                selectSong();
                                WMP.URL = temp.Value.songPath;
                                currentsong = temp.Value;
                                if (string.IsNullOrWhiteSpace(temp.Value.songName))
                                {
                                    lblSongName.Text = Path.GetFileNameWithoutExtension(temp.Value.songPath);
                                }
                                else
                                {
                                    lblSongName.Text = Path.GetFileNameWithoutExtension(temp.Value.songName);
                                }
                                break;
                            }
                            else
                            {
                                searchSong = temp.Value;
                            }
                        }
                    }

                    selectSong();
                    btnPlay.Text = "Pause";
                }
                else
                {
                    WMP.Ctlcontrols.pause();
                    btnPlay.Text = "Play";
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Please add a song to the list \n\nReported Error: " + ex);
            }
        }
        /*
         * When called it selects the item in the listbox 
         * with the same index as the integer value of counter
         */ 
        public void selectSong()
        {
            lbSongs.SetSelected(counter, true);
        }
        /*
         * Goes to the next song by getting the currentsong 
         * than by getting the next song of that.
         */ 
        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                LinkedListNode<Song> temp = musicList.Find(currentsong).Next;
                WMP.URL = temp.Value.songPath;
                currentsong = temp.Value;
                counter++;
                selectSong();
                if (string.IsNullOrWhiteSpace(temp.Value.songName))
                {
                    lblSongName.Text = Path.GetFileNameWithoutExtension(temp.Value.songPath);
                }
                else
                {
                    lblSongName.Text = Path.GetFileNameWithoutExtension(temp.Value.songName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There are no more songs to play");
            }
        }
        /*
         * Goes to the previous song by getting the currentsong 
         * than by getting the previous song of that.
         */
        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (counter == 0)
            {
                MessageBox.Show("There are no previous songs");
            }
            else
            {
                LinkedListNode<Song> temp = musicList.Find(currentsong).Previous;
                WMP.URL = temp.Value.songPath;
                currentsong = temp.Value;
                counter--;
                selectSong();
                if (string.IsNullOrWhiteSpace(temp.Value.songName))
                {
                    lblSongName.Text  = Path.GetFileNameWithoutExtension(temp.Value.songPath);
                }
                else
                {
                    lblSongName.Text = Path.GetFileNameWithoutExtension(temp.Value.songName);
                }
            }
        }
        /*
         * Button Event handler to run the sort method than display method.
         */ 
        private void btnSort_Click(object sender, EventArgs e)
        {
            InsertSort();
            displaySongs();
        }

        /*
         * Simple sort method which is very ineffiency 
         * but works for what it is needed to do by putting all 
         * the songs into List<Song> structure than sorting that and 
         * putting it back into the doubly linked list.
         */
        public void InsertSort()
        {
            List<Song> songs = new List<Song>();
            Song sortCurrentSong = musicList.First();
            songs.Add(musicList.First());


            for (int k = 0; k < musicList.Count - 1; k++)
            {
                LinkedListNode<Song> temp = musicList.Find(sortCurrentSong).Next;
                sortCurrentSong = temp.Value;
                songs.Add(sortCurrentSong);
            }

            int i, j;

            for (i = 1; i < songs.Count; i++)
            {
                Song value = songs[i];
                j = i - 1;
                while ((j >= 0) && (Path.GetFileNameWithoutExtension(songs[j].songPath).CompareTo(Path.GetFileNameWithoutExtension(value.songPath)) > 0))
                {
                    songs[j + 1] = songs[j];
                    j--;
                }
                songs[j + 1] = value;
            }
            musicList.Clear();
            for (int a = 0; a < songs.Count; a++)
            {
                musicList.AddLast(songs[a]);
            }
            displaySongs();
        }

        /*
         * Very simple search algorithms that individually 
         * goes through each song until target text matches the song.
         * To make the code smaller I would use a foreach next time.
         */ 
        private void btnSearch_Click(object sender, EventArgs e)
        {
            bool found = false;
            if (Path.GetFileNameWithoutExtension(musicList.First.Value.songPath).Contains(tbSearch.Text))
            {
                found = true;
                counter = 0;
                selectSong();
            }

            if (!found)
            {
                Song searchSong = musicList.First();
                for (int i = 0; i < musicList.Count - 1; i++)
                {
                    LinkedListNode<Song> temp = musicList.Find(searchSong).Next;
                    if (Path.GetFileNameWithoutExtension(temp.Value.songPath).Contains(tbSearch.Text))
                    {
                        counter = i + 1;
                        selectSong();
                        found = true;
                        break;
                    }
                    else
                    {
                        searchSong = temp.Value;
                    }
                }
            }
            if (!found)
            {
                MessageBox.Show("Couldn't find song!");
            }

        }

        /*
         * Changes the panel to the signup panel.
         */ 
        private void LlblSignup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            signupPanel.Visible = true;
            loginPanel.Visible = false;
        }

        /*
         * Checks if the user exists and if not it adds 
         * them to the database with a hashed password.
         */ 
        private void btnSignup_Click(object sender, EventArgs e)
        {
            if (dbc.checkIfUserExists(tbSUsername.Text))
            {
                dbc.createUser(tbSEmail.Text, tbSUsername.Text, tbSPassword.Text);
                signupPanel.Visible = false;
                session.newSession(dbc.getEmailFromAccount(tbSUsername.Text), tbSUsername.Text, tbSPassword.Text, dbc.getUserID(tbUsername.Text));
                session.loggedIn = true;
                if (session.loggedIn)
                {
                    initialiseClient();
                }
            }
            else
            {
                MessageBox.Show("A user with that username already exisits!");
            }
        }

        //Switches the panels to the login one.
        private void LlblLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            signupPanel.Visible = false;
            loginPanel.Visible = true;
        }

        //Changes the valume depending on the slider.
        private void hSBVolume_ValueChanged(object sender, EventArgs e)
        {
            WMP.settings.volume = hSBVolume.Value;
        }

        //Remove the select song from the listbox, linkedlist and database.
        private void btnRemove_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Your about to remove" + Path.GetFileNameWithoutExtension(selectedSong.songPath) +", Are you sure?", "Music Player", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    dbc.removeSong(selectedSong.userID, selectedSong.songPath);
                    getSongs();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Select a song to remove!\n" + ex);
                }
            }

        }

        /*Set the selected song to whichever one is selected in the 
        listbox by searching for the selected songs string in linked 
            list and counting the number of loops to get the Song Object
        */
        private void lbSongs_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lbSongs.SelectedIndex == 0)
                {
                    selectedSong = musicList.First();
                    btnPlay.Text = "Play";
                }
                else
                {
                    Song searchSong = musicList.First();
                    for (int i = 0; i < musicList.Count - 1; i++)
                    {
                        LinkedListNode<Song> temp = musicList.Find(searchSong).Next;
                        if (Path.GetFileNameWithoutExtension(temp.Value.songPath).Contains(lbSongs.SelectedItem.ToString()))
                        {
                            selectedSong = temp.Value;
                            btnPlay.Text = "Play";
                            break;
                        }
                        else
                        {
                            searchSong = temp.Value;
                        }
                    }
                }

                //selectSong();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Reported Error: " + ex);
            }
        }
        //Checks if the song path still exists if not than it is removed from the database/.
        public void checkIfSongExists()
        {
            foreach(Song song in musicList)
            {
                if (!File.Exists(song.songPath))
                {
                    dbc.removeSong(song.userID, song.songPath);
                }
            }
        }

        //Detects if Control + D is pressed than closes the program/
        private void MusicPlayer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.D)
            {
                this.Close();
            }
        }
    }
}
