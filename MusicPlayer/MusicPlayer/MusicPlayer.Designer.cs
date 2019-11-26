namespace MusicPlayer
{
    partial class MusicPlayer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MusicPlayer));
            this.loginPanel = new System.Windows.Forms.Panel();
            this.LlblSignup = new System.Windows.Forms.LinkLabel();
            this.lblDontAccount = new System.Windows.Forms.Label();
            this.lblOr = new System.Windows.Forms.Label();
            this.lblMusicPlayer = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.lblProfileName = new System.Windows.Forms.Label();
            this.WMP = new AxWMPLib.AxWindowsMediaPlayer();
            this.musicPanel = new System.Windows.Forms.Panel();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnSort = new System.Windows.Forms.Button();
            this.btnAddSong = new System.Windows.Forms.Button();
            this.lbSongs = new System.Windows.Forms.ListBox();
            this.lblSongName = new System.Windows.Forms.Label();
            this.signupPanel = new System.Windows.Forms.Panel();
            this.tbSUsername = new System.Windows.Forms.TextBox();
            this.LlblLogin = new System.Windows.Forms.LinkLabel();
            this.lblHaveAccount = new System.Windows.Forms.Label();
            this.lblSOr = new System.Windows.Forms.Label();
            this.lblSMusicPlayer = new System.Windows.Forms.Label();
            this.btnSignup = new System.Windows.Forms.Button();
            this.tbSEmail = new System.Windows.Forms.TextBox();
            this.tbSPassword = new System.Windows.Forms.TextBox();
            this.loginPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WMP)).BeginInit();
            this.musicPanel.SuspendLayout();
            this.signupPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // loginPanel
            // 
            this.loginPanel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.loginPanel.Controls.Add(this.LlblSignup);
            this.loginPanel.Controls.Add(this.lblDontAccount);
            this.loginPanel.Controls.Add(this.lblOr);
            this.loginPanel.Controls.Add(this.lblMusicPlayer);
            this.loginPanel.Controls.Add(this.btnLogin);
            this.loginPanel.Controls.Add(this.tbUsername);
            this.loginPanel.Controls.Add(this.tbPassword);
            this.loginPanel.Location = new System.Drawing.Point(424, 57);
            this.loginPanel.Name = "loginPanel";
            this.loginPanel.Size = new System.Drawing.Size(292, 423);
            this.loginPanel.TabIndex = 1;
            // 
            // LlblSignup
            // 
            this.LlblSignup.AutoSize = true;
            this.LlblSignup.Font = new System.Drawing.Font("Maiandra GD", 12F, System.Drawing.FontStyle.Bold);
            this.LlblSignup.LinkColor = System.Drawing.Color.Black;
            this.LlblSignup.Location = new System.Drawing.Point(209, 305);
            this.LlblSignup.Name = "LlblSignup";
            this.LlblSignup.Size = new System.Drawing.Size(61, 19);
            this.LlblSignup.TabIndex = 6;
            this.LlblSignup.TabStop = true;
            this.LlblSignup.Text = "Signup";
            this.LlblSignup.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LlblSignup_LinkClicked);
            // 
            // lblDontAccount
            // 
            this.lblDontAccount.AutoSize = true;
            this.lblDontAccount.Font = new System.Drawing.Font("Maiandra GD", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDontAccount.Location = new System.Drawing.Point(15, 305);
            this.lblDontAccount.Name = "lblDontAccount";
            this.lblDontAccount.Size = new System.Drawing.Size(197, 19);
            this.lblDontAccount.TabIndex = 5;
            this.lblDontAccount.Text = "Don\'t have an account?";
            // 
            // lblOr
            // 
            this.lblOr.AutoSize = true;
            this.lblOr.Font = new System.Drawing.Font("Maiandra GD", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOr.Location = new System.Drawing.Point(117, 247);
            this.lblOr.Name = "lblOr";
            this.lblOr.Size = new System.Drawing.Size(60, 35);
            this.lblOr.TabIndex = 4;
            this.lblOr.Text = "OR";
            // 
            // lblMusicPlayer
            // 
            this.lblMusicPlayer.AutoSize = true;
            this.lblMusicPlayer.Font = new System.Drawing.Font("Maiandra GD", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMusicPlayer.Location = new System.Drawing.Point(51, 37);
            this.lblMusicPlayer.Name = "lblMusicPlayer";
            this.lblMusicPlayer.Size = new System.Drawing.Size(186, 35);
            this.lblMusicPlayer.TabIndex = 3;
            this.lblMusicPlayer.Text = "Music Player";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(29, 189);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(235, 35);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // tbUsername
            // 
            this.tbUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbUsername.Location = new System.Drawing.Point(29, 93);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(235, 27);
            this.tbUsername.TabIndex = 1;
            this.tbUsername.Text = "Username";
            // 
            // tbPassword
            // 
            this.tbPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPassword.Location = new System.Drawing.Point(29, 141);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(235, 27);
            this.tbPassword.TabIndex = 0;
            this.tbPassword.Text = "Password";
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(505, 533);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(95, 38);
            this.btnPlay.TabIndex = 2;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Location = new System.Drawing.Point(404, 533);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(95, 38);
            this.btnPrev.TabIndex = 3;
            this.btnPrev.Text = "Previous";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(606, 533);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(95, 38);
            this.btnNext.TabIndex = 4;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // lblProfileName
            // 
            this.lblProfileName.AutoSize = true;
            this.lblProfileName.Font = new System.Drawing.Font("Maiandra GD", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProfileName.ForeColor = System.Drawing.Color.White;
            this.lblProfileName.Location = new System.Drawing.Point(12, 9);
            this.lblProfileName.Name = "lblProfileName";
            this.lblProfileName.Size = new System.Drawing.Size(141, 35);
            this.lblProfileName.TabIndex = 7;
            this.lblProfileName.Text = "Welcome";
            // 
            // WMP
            // 
            this.WMP.Enabled = true;
            this.WMP.Location = new System.Drawing.Point(911, 12);
            this.WMP.Name = "WMP";
            this.WMP.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("WMP.OcxState")));
            this.WMP.Size = new System.Drawing.Size(231, 120);
            this.WMP.TabIndex = 1;
            this.WMP.Visible = false;
            // 
            // musicPanel
            // 
            this.musicPanel.Controls.Add(this.tbSearch);
            this.musicPanel.Controls.Add(this.btnSearch);
            this.musicPanel.Controls.Add(this.btnSort);
            this.musicPanel.Controls.Add(this.btnAddSong);
            this.musicPanel.Controls.Add(this.lbSongs);
            this.musicPanel.Controls.Add(this.lblSongName);
            this.musicPanel.Controls.Add(this.btnNext);
            this.musicPanel.Controls.Add(this.lblProfileName);
            this.musicPanel.Controls.Add(this.btnPlay);
            this.musicPanel.Controls.Add(this.btnPrev);
            this.musicPanel.Location = new System.Drawing.Point(12, 12);
            this.musicPanel.Name = "musicPanel";
            this.musicPanel.Size = new System.Drawing.Size(1130, 595);
            this.musicPanel.TabIndex = 0;
            this.musicPanel.Visible = false;
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(222, 563);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(100, 20);
            this.tbSearch.TabIndex = 13;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(222, 521);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 23);
            this.btnSearch.TabIndex = 12;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnSort
            // 
            this.btnSort.Location = new System.Drawing.Point(119, 533);
            this.btnSort.Name = "btnSort";
            this.btnSort.Size = new System.Drawing.Size(97, 38);
            this.btnSort.TabIndex = 11;
            this.btnSort.Text = "Sort";
            this.btnSort.UseVisualStyleBackColor = true;
            this.btnSort.Click += new System.EventHandler(this.btnSort_Click);
            // 
            // btnAddSong
            // 
            this.btnAddSong.Location = new System.Drawing.Point(18, 533);
            this.btnAddSong.Name = "btnAddSong";
            this.btnAddSong.Size = new System.Drawing.Size(95, 38);
            this.btnAddSong.TabIndex = 10;
            this.btnAddSong.Text = "Add Song";
            this.btnAddSong.UseVisualStyleBackColor = true;
            this.btnAddSong.Click += new System.EventHandler(this.btnAddSong_Click);
            // 
            // lbSongs
            // 
            this.lbSongs.FormattingEnabled = true;
            this.lbSongs.Location = new System.Drawing.Point(18, 60);
            this.lbSongs.Name = "lbSongs";
            this.lbSongs.Size = new System.Drawing.Size(368, 420);
            this.lbSongs.TabIndex = 9;
            // 
            // lblSongName
            // 
            this.lblSongName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSongName.Font = new System.Drawing.Font("Maiandra GD", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSongName.ForeColor = System.Drawing.Color.White;
            this.lblSongName.Location = new System.Drawing.Point(173, 490);
            this.lblSongName.Name = "lblSongName";
            this.lblSongName.Size = new System.Drawing.Size(778, 35);
            this.lblSongName.TabIndex = 8;
            this.lblSongName.Text = "Song Name";
            this.lblSongName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // signupPanel
            // 
            this.signupPanel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.signupPanel.Controls.Add(this.tbSUsername);
            this.signupPanel.Controls.Add(this.LlblLogin);
            this.signupPanel.Controls.Add(this.lblHaveAccount);
            this.signupPanel.Controls.Add(this.lblSOr);
            this.signupPanel.Controls.Add(this.lblSMusicPlayer);
            this.signupPanel.Controls.Add(this.btnSignup);
            this.signupPanel.Controls.Add(this.tbSEmail);
            this.signupPanel.Controls.Add(this.tbSPassword);
            this.signupPanel.Location = new System.Drawing.Point(431, 57);
            this.signupPanel.Name = "signupPanel";
            this.signupPanel.Size = new System.Drawing.Size(292, 423);
            this.signupPanel.TabIndex = 7;
            this.signupPanel.Visible = false;
            // 
            // tbSUsername
            // 
            this.tbSUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSUsername.Location = new System.Drawing.Point(29, 126);
            this.tbSUsername.Name = "tbSUsername";
            this.tbSUsername.Size = new System.Drawing.Size(235, 27);
            this.tbSUsername.TabIndex = 7;
            this.tbSUsername.Text = "Username";
            // 
            // LlblLogin
            // 
            this.LlblLogin.AutoSize = true;
            this.LlblLogin.Font = new System.Drawing.Font("Maiandra GD", 12F, System.Drawing.FontStyle.Bold);
            this.LlblLogin.LinkColor = System.Drawing.Color.Black;
            this.LlblLogin.Location = new System.Drawing.Point(222, 305);
            this.LlblLogin.Name = "LlblLogin";
            this.LlblLogin.Size = new System.Drawing.Size(52, 19);
            this.LlblLogin.TabIndex = 6;
            this.LlblLogin.TabStop = true;
            this.LlblLogin.Text = "Login";
            this.LlblLogin.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LlblLogin_LinkClicked);
            // 
            // lblHaveAccount
            // 
            this.lblHaveAccount.AutoSize = true;
            this.lblHaveAccount.Font = new System.Drawing.Font("Maiandra GD", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHaveAccount.Location = new System.Drawing.Point(7, 305);
            this.lblHaveAccount.Name = "lblHaveAccount";
            this.lblHaveAccount.Size = new System.Drawing.Size(214, 19);
            this.lblHaveAccount.TabIndex = 5;
            this.lblHaveAccount.Text = "Already have an account?";
            // 
            // lblSOr
            // 
            this.lblSOr.AutoSize = true;
            this.lblSOr.Font = new System.Drawing.Font("Maiandra GD", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSOr.Location = new System.Drawing.Point(117, 247);
            this.lblSOr.Name = "lblSOr";
            this.lblSOr.Size = new System.Drawing.Size(60, 35);
            this.lblSOr.TabIndex = 4;
            this.lblSOr.Text = "OR";
            // 
            // lblSMusicPlayer
            // 
            this.lblSMusicPlayer.AutoSize = true;
            this.lblSMusicPlayer.Font = new System.Drawing.Font("Maiandra GD", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSMusicPlayer.Location = new System.Drawing.Point(51, 37);
            this.lblSMusicPlayer.Name = "lblSMusicPlayer";
            this.lblSMusicPlayer.Size = new System.Drawing.Size(186, 35);
            this.lblSMusicPlayer.TabIndex = 3;
            this.lblSMusicPlayer.Text = "Music Player";
            // 
            // btnSignup
            // 
            this.btnSignup.Location = new System.Drawing.Point(29, 192);
            this.btnSignup.Name = "btnSignup";
            this.btnSignup.Size = new System.Drawing.Size(235, 35);
            this.btnSignup.TabIndex = 2;
            this.btnSignup.Text = "Signup";
            this.btnSignup.UseVisualStyleBackColor = true;
            this.btnSignup.Click += new System.EventHandler(this.btnSignup_Click);
            // 
            // tbSEmail
            // 
            this.tbSEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSEmail.Location = new System.Drawing.Point(29, 93);
            this.tbSEmail.Name = "tbSEmail";
            this.tbSEmail.Size = new System.Drawing.Size(235, 27);
            this.tbSEmail.TabIndex = 1;
            this.tbSEmail.Text = "Email";
            // 
            // tbSPassword
            // 
            this.tbSPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSPassword.Location = new System.Drawing.Point(29, 159);
            this.tbSPassword.Name = "tbSPassword";
            this.tbSPassword.Size = new System.Drawing.Size(235, 27);
            this.tbSPassword.TabIndex = 0;
            this.tbSPassword.Text = "Password";
            // 
            // MusicPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.ClientSize = new System.Drawing.Size(1154, 610);
            this.Controls.Add(this.WMP);
            this.Controls.Add(this.musicPanel);
            this.Controls.Add(this.loginPanel);
            this.Controls.Add(this.signupPanel);
            this.Name = "MusicPlayer";
            this.Text = "Music Player";
            this.loginPanel.ResumeLayout(false);
            this.loginPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WMP)).EndInit();
            this.musicPanel.ResumeLayout(false);
            this.musicPanel.PerformLayout();
            this.signupPanel.ResumeLayout(false);
            this.signupPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel loginPanel;
        private System.Windows.Forms.LinkLabel LlblSignup;
        private System.Windows.Forms.Label lblDontAccount;
        private System.Windows.Forms.Label lblOr;
        private System.Windows.Forms.Label lblMusicPlayer;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label lblProfileName;
        private AxWMPLib.AxWindowsMediaPlayer WMP;
        private System.Windows.Forms.Panel musicPanel;
        private System.Windows.Forms.ListBox lbSongs;
        private System.Windows.Forms.Label lblSongName;
        private System.Windows.Forms.Button btnAddSong;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnSort;
        private System.Windows.Forms.Panel signupPanel;
        private System.Windows.Forms.TextBox tbSUsername;
        private System.Windows.Forms.LinkLabel LlblLogin;
        private System.Windows.Forms.Label lblHaveAccount;
        private System.Windows.Forms.Label lblSOr;
        private System.Windows.Forms.Label lblSMusicPlayer;
        private System.Windows.Forms.Button btnSignup;
        private System.Windows.Forms.TextBox tbSEmail;
        private System.Windows.Forms.TextBox tbSPassword;
    }
}

