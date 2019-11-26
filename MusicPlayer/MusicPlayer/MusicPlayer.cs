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

namespace MusicPlayer
{
    public partial class MusicPlayer : Form
    {
        private DBC dbc = new DBC();
        private Session session = new Session();
        private List<string> songs = new List<string>();
        private int counter = 0;
        private string currentsong;
        public MusicPlayer()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (dbc.login(tbUsername.Text, tbPassword.Text))
            {
                session.newSession(dbc.getEmailFromAccount(tbUsername.Text), tbUsername.Text, tbPassword.Text);
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
        public void initialiseClient()
        {
            lblProfileName.Text = "Welcome " + session.username;
            musicPanel.Visible = true;
        }

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
                            songs.Add(fileName);
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

        public void displaySongs()
        {
            lbSongs.Items.Clear();
            foreach (string song in songs)
            {
                string file = Path.GetFileNameWithoutExtension(song);
                lbSongs.Items.Add(file);
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentsong == null)
                {
                    WMP.URL = songs.First();
                    currentsong = songs.First();
                    counter = 0;
                    lblSongName.Text = Path.GetFileNameWithoutExtension(songs[counter]);
                    selectSong();
                }
                else
                {
                    WMP.Ctlcontrols.play();
                    selectSong();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Please add a song to the list \n\nReported Error: " + ex);
            }
        }

        public void selectSong()
        {
            lbSongs.SetSelected(counter, true);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                WMP.URL = songs[counter + 1];
                counter++;
                lblSongName.Text = Path.GetFileNameWithoutExtension(songs[counter]);
                selectSong();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There are no more songs to play");
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (counter == 0)
            {
                MessageBox.Show("There are no previous songs");
            }
            else
            {
                WMP.URL = songs[counter - 1];
                counter--;
                lblSongName.Text = Path.GetFileNameWithoutExtension(songs[counter]);
                selectSong();
            }
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            bubbleSort();
            displaySongs();
        }

        public void bubbleSort()
        {
            int pos = 1;
            while (pos < songs.Count)
            {
                if (string.CompareOrdinal(songs[pos], songs[pos - 1]) >= 0 || songs[pos] == "~empty")
                {
                    pos++;
                }
                else
                {

                    arrayAlphabeticSwap(songs, pos);

                    if (pos > 1)
                    {
                        pos--;
                    }
                }
            }
        }
        //Takes the info from the bubblesort and does the swap.
        public void arrayAlphabeticSwap(List<string> array, int pos)
        {
            string temp;
            temp = array[pos];
            array[pos] = array[pos - 1];
            array[pos - 1] = temp;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            bool found = false;
            if (string.IsNullOrWhiteSpace(tbSearch.Text))
            {
                MessageBox.Show("Please enter a word to search");
            }
            else
            {
                for(int i = 0; i < songs.Count; i++)
                {
                    string song = Path.GetFileNameWithoutExtension(songs[i]);
                    if (song.Contains(tbSearch.Text))
                    {
                        counter = i;
                        WMP.URL = songs[i];
                        currentsong = songs[i];
                        selectSong();
                        lblSongName.Text = Path.GetFileNameWithoutExtension(songs[counter]);
                        found = true;
                        break;
                    }else
                    {
                    }
                }
                if(found == false)
                {
                    MessageBox.Show("Couldn't find song");
                }
            }
        }

        private void LlblSignup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            signupPanel.Visible = true;
            loginPanel.Visible = false;
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            if (dbc.checkIfUserExists(tbUsername.Text))
            {
                MessageBox.Show("An account with that username already exists.");
            }
            else
            {
                dbc.createUser(tbSEmail.Text, tbSUsername.Text, tbSPassword.Text);
                if (dbc.checkIfUserExists(tbSUsername.Text))
                {
                    signupPanel.Visible = false;
                    session.newSession(dbc.getEmailFromAccount(tbSUsername.Text), tbSUsername.Text, tbSPassword.Text);
                    session.loggedIn = true;
                    if (session.loggedIn)
                    {
                        initialiseClient();
                    }
                }
                else
                {
                    MessageBox.Show("An Error has occured");
                }
            }
        }

        private void LlblLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            signupPanel.Visible = false;
            loginPanel.Visible = true;
        }
    }
}
