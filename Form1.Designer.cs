using System.Windows.Forms;

namespace RoundRobin
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ContextMenuStripPlayer = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuItemAbandon = new System.Windows.Forms.ToolStripMenuItem();
            this.TabPageRankings = new System.Windows.Forms.TabPage();
            this.Label2 = new System.Windows.Forms.Label();
            this.DataGridViewRankings = new System.Windows.Forms.DataGridView();
            this.TabPageMatches = new System.Windows.Forms.TabPage();
            this.DataGridViewMatches = new System.Windows.Forms.DataGridView();
            this.ComboBoxRound = new System.Windows.Forms.ComboBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.BtnPreviousRound = new System.Windows.Forms.Button();
            this.BtnNextRound = new System.Windows.Forms.Button();
            this.LabelMatchHelp = new System.Windows.Forms.Label();
            this.TabPageSetup = new System.Windows.Forms.TabPage();
            this.Label1 = new System.Windows.Forms.Label();
            this.ListBoxPlayers = new System.Windows.Forms.CheckedListBox();
            this.TxtPlayerName = new System.Windows.Forms.TextBox();
            this.BtnAddPlayer = new System.Windows.Forms.Button();
            this.BtnGenerateMatches = new System.Windows.Forms.Button();
            this.BtnResetTournament = new System.Windows.Forms.Button();
            this.GroupBoxTournamentInfo = new System.Windows.Forms.GroupBox();
            this.LabelTotalMatches = new System.Windows.Forms.Label();
            this.LabelTotalRounds = new System.Windows.Forms.Label();
            this.LabelDuration3Sets = new System.Windows.Forms.Label();
            this.LabelDuration5Sets = new System.Windows.Forms.Label();
            this.LabelDurationPerRound3Sets = new System.Windows.Forms.Label();
            this.LabelDurationPerRound5Sets = new System.Windows.Forms.Label();
            this.BtnLoadFromFile = new System.Windows.Forms.Button();
            this.BtnUncheckAll = new System.Windows.Forms.Button();
            this.BtnCheckAll = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ToolStripStatusLableCopyright = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.ContextMenuStripPlayer.SuspendLayout();
            this.TabPageRankings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewRankings)).BeginInit();
            this.TabPageMatches.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewMatches)).BeginInit();
            this.TabPageSetup.SuspendLayout();
            this.GroupBoxTournamentInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.ToolStripStatusLableCopyright.SuspendLayout();
            this.TabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ContextMenuStripPlayer
            // 
            this.ContextMenuStripPlayer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemAbandon});
            this.ContextMenuStripPlayer.Name = "ContextMenuStripPlayer";
            this.ContextMenuStripPlayer.Size = new System.Drawing.Size(174, 26);
            // 
            // MenuItemAbandon
            // 
            this.MenuItemAbandon.Name = "MenuItemAbandon";
            this.MenuItemAbandon.Size = new System.Drawing.Size(173, 22);
            this.MenuItemAbandon.Text = "Déclarer l\'abandon";
            this.MenuItemAbandon.Click += new System.EventHandler(this.MenuItemAbandon_Click);
            // 
            // TabPageRankings
            // 
            this.TabPageRankings.Controls.Add(this.DataGridViewRankings);
            this.TabPageRankings.Controls.Add(this.Label2);
            this.TabPageRankings.Location = new System.Drawing.Point(4, 22);
            this.TabPageRankings.Name = "TabPageRankings";
            this.TabPageRankings.Size = new System.Drawing.Size(992, 605);
            this.TabPageRankings.TabIndex = 2;
            this.TabPageRankings.Text = "Classement";
            this.TabPageRankings.UseVisualStyleBackColor = true;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.Label2.Location = new System.Drawing.Point(16, 20);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(103, 20);
            this.Label2.TabIndex = 0;
            this.Label2.Text = "Classement";
            // 
            // DataGridViewRankings
            // 
            this.DataGridViewRankings.AllowUserToAddRows = false;
            this.DataGridViewRankings.AllowUserToDeleteRows = false;
            this.DataGridViewRankings.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridViewRankings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewRankings.Location = new System.Drawing.Point(20, 50);
            this.DataGridViewRankings.Name = "DataGridViewRankings";
            this.DataGridViewRankings.ReadOnly = true;
            this.DataGridViewRankings.Size = new System.Drawing.Size(950, 500);
            this.DataGridViewRankings.TabIndex = 1;
            // 
            // TabPageMatches
            // 
            this.TabPageMatches.Controls.Add(this.LabelMatchHelp);
            this.TabPageMatches.Controls.Add(this.BtnNextRound);
            this.TabPageMatches.Controls.Add(this.BtnPreviousRound);
            this.TabPageMatches.Controls.Add(this.Label5);
            this.TabPageMatches.Controls.Add(this.ComboBoxRound);
            this.TabPageMatches.Controls.Add(this.DataGridViewMatches);
            this.TabPageMatches.Location = new System.Drawing.Point(4, 22);
            this.TabPageMatches.Name = "TabPageMatches";
            this.TabPageMatches.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageMatches.Size = new System.Drawing.Size(992, 605);
            this.TabPageMatches.TabIndex = 1;
            this.TabPageMatches.Text = "Matchs";
            this.TabPageMatches.UseVisualStyleBackColor = true;
            // 
            // DataGridViewMatches
            // 
            this.DataGridViewMatches.AllowUserToAddRows = false;
            this.DataGridViewMatches.AllowUserToDeleteRows = false;
            this.DataGridViewMatches.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewMatches.Location = new System.Drawing.Point(20, 50);
            this.DataGridViewMatches.MultiSelect = false;
            this.DataGridViewMatches.Name = "DataGridViewMatches";
            this.DataGridViewMatches.ReadOnly = true;
            this.DataGridViewMatches.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridViewMatches.Size = new System.Drawing.Size(950, 460);
            this.DataGridViewMatches.TabIndex = 0;
            this.DataGridViewMatches.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewMatches_CellDoubleClick);
            this.DataGridViewMatches.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridViewMatches_CellMouseDown);
            // 
            // ComboBoxRound
            // 
            this.ComboBoxRound.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxRound.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ComboBoxRound.FormattingEnabled = true;
            this.ComboBoxRound.Location = new System.Drawing.Point(70, 14);
            this.ComboBoxRound.Name = "ComboBoxRound";
            this.ComboBoxRound.Size = new System.Drawing.Size(150, 24);
            this.ComboBoxRound.TabIndex = 6;
            this.ComboBoxRound.SelectedIndexChanged += new System.EventHandler(this.ComboBoxRound_SelectedIndexChanged);
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.Label5.Location = new System.Drawing.Point(17, 17);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(47, 17);
            this.Label5.TabIndex = 7;
            this.Label5.Text = "Tour:";
            // 
            // BtnPreviousRound
            // 
            this.BtnPreviousRound.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.BtnPreviousRound.Location = new System.Drawing.Point(240, 12);
            this.BtnPreviousRound.Name = "BtnPreviousRound";
            this.BtnPreviousRound.Size = new System.Drawing.Size(40, 28);
            this.BtnPreviousRound.TabIndex = 8;
            this.BtnPreviousRound.Text = "◄";
            this.BtnPreviousRound.UseVisualStyleBackColor = true;
            this.BtnPreviousRound.Click += new System.EventHandler(this.BtnPreviousRound_Click);
            // 
            // BtnNextRound
            // 
            this.BtnNextRound.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.BtnNextRound.Location = new System.Drawing.Point(286, 12);
            this.BtnNextRound.Name = "BtnNextRound";
            this.BtnNextRound.Size = new System.Drawing.Size(40, 28);
            this.BtnNextRound.TabIndex = 9;
            this.BtnNextRound.Text = "►";
            this.BtnNextRound.UseVisualStyleBackColor = true;
            this.BtnNextRound.Click += new System.EventHandler(this.BtnNextRound_Click);
            // 
            // LabelMatchHelp
            // 
            this.LabelMatchHelp.AutoSize = true;
            this.LabelMatchHelp.Location = new System.Drawing.Point(272, 539);
            this.LabelMatchHelp.Name = "LabelMatchHelp";
            this.LabelMatchHelp.Size = new System.Drawing.Size(448, 52);
            this.LabelMatchHelp.TabIndex = 10;
            this.LabelMatchHelp.Text = resources.GetString("LabelMatchHelp.Text");
            // 
            // TabPageSetup
            // 
            this.TabPageSetup.Controls.Add(this.ToolStripStatusLableCopyright);
            this.TabPageSetup.Controls.Add(this.pictureBox1);
            this.TabPageSetup.Controls.Add(this.BtnCheckAll);
            this.TabPageSetup.Controls.Add(this.BtnUncheckAll);
            this.TabPageSetup.Controls.Add(this.BtnLoadFromFile);
            this.TabPageSetup.Controls.Add(this.GroupBoxTournamentInfo);
            this.TabPageSetup.Controls.Add(this.BtnResetTournament);
            this.TabPageSetup.Controls.Add(this.BtnGenerateMatches);
            this.TabPageSetup.Controls.Add(this.BtnAddPlayer);
            this.TabPageSetup.Controls.Add(this.TxtPlayerName);
            this.TabPageSetup.Controls.Add(this.ListBoxPlayers);
            this.TabPageSetup.Controls.Add(this.Label1);
            this.TabPageSetup.Location = new System.Drawing.Point(4, 22);
            this.TabPageSetup.Name = "TabPageSetup";
            this.TabPageSetup.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageSetup.Size = new System.Drawing.Size(992, 605);
            this.TabPageSetup.TabIndex = 0;
            this.TabPageSetup.Text = "Configuration";
            this.TabPageSetup.UseVisualStyleBackColor = true;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.Label1.Location = new System.Drawing.Point(17, 62);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(62, 15);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Joueurs:";
            // 
            // ListBoxPlayers
            // 
            this.ListBoxPlayers.CheckOnClick = true;
            this.ListBoxPlayers.FormattingEnabled = true;
            this.ListBoxPlayers.Location = new System.Drawing.Point(20, 80);
            this.ListBoxPlayers.Name = "ListBoxPlayers";
            this.ListBoxPlayers.Size = new System.Drawing.Size(300, 394);
            this.ListBoxPlayers.TabIndex = 1;
            // 
            // TxtPlayerName
            // 
            this.TxtPlayerName.Location = new System.Drawing.Point(20, 32);
            this.TxtPlayerName.Name = "TxtPlayerName";
            this.TxtPlayerName.Size = new System.Drawing.Size(219, 20);
            this.TxtPlayerName.TabIndex = 2;
            // 
            // BtnAddPlayer
            // 
            this.BtnAddPlayer.Location = new System.Drawing.Point(245, 30);
            this.BtnAddPlayer.Name = "BtnAddPlayer";
            this.BtnAddPlayer.Size = new System.Drawing.Size(75, 23);
            this.BtnAddPlayer.TabIndex = 3;
            this.BtnAddPlayer.Text = "Ajouter";
            this.BtnAddPlayer.UseVisualStyleBackColor = true;
            this.BtnAddPlayer.Click += new System.EventHandler(this.BtnAddPlayer_Click);
            // 
            // BtnGenerateMatches
            // 
            this.BtnGenerateMatches.Enabled = false;
            this.BtnGenerateMatches.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.BtnGenerateMatches.Location = new System.Drawing.Point(355, 259);
            this.BtnGenerateMatches.Name = "BtnGenerateMatches";
            this.BtnGenerateMatches.Size = new System.Drawing.Size(300, 40);
            this.BtnGenerateMatches.TabIndex = 4;
            this.BtnGenerateMatches.Text = "Générer les matchs par tour";
            this.BtnGenerateMatches.UseVisualStyleBackColor = true;
            this.BtnGenerateMatches.Click += new System.EventHandler(this.BtnGenerateMatches_Click);
            // 
            // BtnResetTournament
            // 
            this.BtnResetTournament.Location = new System.Drawing.Point(355, 323);
            this.BtnResetTournament.Name = "BtnResetTournament";
            this.BtnResetTournament.Size = new System.Drawing.Size(300, 40);
            this.BtnResetTournament.TabIndex = 5;
            this.BtnResetTournament.Text = "Réinitialiser le tournoi";
            this.BtnResetTournament.UseVisualStyleBackColor = true;
            this.BtnResetTournament.Click += new System.EventHandler(this.BtnResetTournament_Click);
            // 
            // GroupBoxTournamentInfo
            // 
            this.GroupBoxTournamentInfo.Controls.Add(this.LabelDurationPerRound5Sets);
            this.GroupBoxTournamentInfo.Controls.Add(this.LabelDurationPerRound3Sets);
            this.GroupBoxTournamentInfo.Controls.Add(this.LabelDuration5Sets);
            this.GroupBoxTournamentInfo.Controls.Add(this.LabelDuration3Sets);
            this.GroupBoxTournamentInfo.Controls.Add(this.LabelTotalRounds);
            this.GroupBoxTournamentInfo.Controls.Add(this.LabelTotalMatches);
            this.GroupBoxTournamentInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.GroupBoxTournamentInfo.Location = new System.Drawing.Point(355, 17);
            this.GroupBoxTournamentInfo.Name = "GroupBoxTournamentInfo";
            this.GroupBoxTournamentInfo.Size = new System.Drawing.Size(300, 220);
            this.GroupBoxTournamentInfo.TabIndex = 6;
            this.GroupBoxTournamentInfo.TabStop = false;
            this.GroupBoxTournamentInfo.Text = "📊 Informations sur le tournoi";
            // 
            // LabelTotalMatches
            // 
            this.LabelTotalMatches.AutoSize = true;
            this.LabelTotalMatches.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.LabelTotalMatches.Location = new System.Drawing.Point(15, 30);
            this.LabelTotalMatches.Name = "LabelTotalMatches";
            this.LabelTotalMatches.Size = new System.Drawing.Size(111, 15);
            this.LabelTotalMatches.TabIndex = 0;
            this.LabelTotalMatches.Text = "Total de matchs : --";
            // 
            // LabelTotalRounds
            // 
            this.LabelTotalRounds.AutoSize = true;
            this.LabelTotalRounds.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.LabelTotalRounds.Location = new System.Drawing.Point(15, 55);
            this.LabelTotalRounds.Name = "LabelTotalRounds";
            this.LabelTotalRounds.Size = new System.Drawing.Size(116, 15);
            this.LabelTotalRounds.TabIndex = 1;
            this.LabelTotalRounds.Text = "Nombre de tours : --";
            // 
            // LabelDuration3Sets
            // 
            this.LabelDuration3Sets.AutoSize = true;
            this.LabelDuration3Sets.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.LabelDuration3Sets.ForeColor = System.Drawing.Color.DarkGreen;
            this.LabelDuration3Sets.Location = new System.Drawing.Point(15, 90);
            this.LabelDuration3Sets.Name = "LabelDuration3Sets";
            this.LabelDuration3Sets.Size = new System.Drawing.Size(194, 15);
            this.LabelDuration3Sets.TabIndex = 2;
            this.LabelDuration3Sets.Text = "⏱️ Durée estimée (3 manches) : --";
            // 
            // LabelDuration5Sets
            // 
            this.LabelDuration5Sets.AutoSize = true;
            this.LabelDuration5Sets.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.LabelDuration5Sets.ForeColor = System.Drawing.Color.DarkOrange;
            this.LabelDuration5Sets.Location = new System.Drawing.Point(15, 115);
            this.LabelDuration5Sets.Name = "LabelDuration5Sets";
            this.LabelDuration5Sets.Size = new System.Drawing.Size(194, 15);
            this.LabelDuration5Sets.TabIndex = 3;
            this.LabelDuration5Sets.Text = "⏱️ Durée estimée (5 manches) : --";
            // 
            // LabelDurationPerRound3Sets
            // 
            this.LabelDurationPerRound3Sets.AutoSize = true;
            this.LabelDurationPerRound3Sets.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Italic);
            this.LabelDurationPerRound3Sets.ForeColor = System.Drawing.Color.Gray;
            this.LabelDurationPerRound3Sets.Location = new System.Drawing.Point(35, 140);
            this.LabelDurationPerRound3Sets.Name = "LabelDurationPerRound3Sets";
            this.LabelDurationPerRound3Sets.Size = new System.Drawing.Size(162, 15);
            this.LabelDurationPerRound3Sets.TabIndex = 4;
            this.LabelDurationPerRound3Sets.Text = "   Par tour : -- (15 min/match)";
            // 
            // LabelDurationPerRound5Sets
            // 
            this.LabelDurationPerRound5Sets.AutoSize = true;
            this.LabelDurationPerRound5Sets.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Italic);
            this.LabelDurationPerRound5Sets.ForeColor = System.Drawing.Color.Gray;
            this.LabelDurationPerRound5Sets.Location = new System.Drawing.Point(35, 165);
            this.LabelDurationPerRound5Sets.Name = "LabelDurationPerRound5Sets";
            this.LabelDurationPerRound5Sets.Size = new System.Drawing.Size(162, 15);
            this.LabelDurationPerRound5Sets.TabIndex = 5;
            this.LabelDurationPerRound5Sets.Text = "   Par tour : -- (25 min/match)";
            // 
            // BtnLoadFromFile
            // 
            this.BtnLoadFromFile.Location = new System.Drawing.Point(20, 536);
            this.BtnLoadFromFile.Name = "BtnLoadFromFile";
            this.BtnLoadFromFile.Size = new System.Drawing.Size(300, 30);
            this.BtnLoadFromFile.TabIndex = 7;
            this.BtnLoadFromFile.Text = "📂 Charger la liste depuis un fichier";
            this.BtnLoadFromFile.UseVisualStyleBackColor = true;
            this.BtnLoadFromFile.Click += new System.EventHandler(this.BtnLoadFromFile_Click);
            // 
            // BtnUncheckAll
            // 
            this.BtnUncheckAll.Location = new System.Drawing.Point(218, 482);
            this.BtnUncheckAll.Name = "BtnUncheckAll";
            this.BtnUncheckAll.Size = new System.Drawing.Size(102, 23);
            this.BtnUncheckAll.TabIndex = 9;
            this.BtnUncheckAll.Text = "Tout décocher";
            this.BtnUncheckAll.UseVisualStyleBackColor = true;
            this.BtnUncheckAll.Click += new System.EventHandler(this.BtnUncheckAll_Click);
            // 
            // BtnCheckAll
            // 
            this.BtnCheckAll.Location = new System.Drawing.Point(20, 482);
            this.BtnCheckAll.Name = "BtnCheckAll";
            this.BtnCheckAll.Size = new System.Drawing.Size(104, 23);
            this.BtnCheckAll.TabIndex = 8;
            this.BtnCheckAll.Text = "Tout cocher";
            this.BtnCheckAll.UseVisualStyleBackColor = true;
            this.BtnCheckAll.Click += new System.EventHandler(this.BtnCheckAll_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::RoundRobin.Properties.Resources.Logo;
            this.pictureBox1.Location = new System.Drawing.Point(705, 17);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(284, 549);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // ToolStripStatusLableCopyright
            // 
            this.ToolStripStatusLableCopyright.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.ToolStripStatusLableCopyright.Location = new System.Drawing.Point(3, 580);
            this.ToolStripStatusLableCopyright.Name = "ToolStripStatusLableCopyright";
            this.ToolStripStatusLableCopyright.Size = new System.Drawing.Size(986, 22);
            this.ToolStripStatusLableCopyright.TabIndex = 11;
            this.ToolStripStatusLableCopyright.Text = "(c) 2026 Patrick CH.";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(971, 17);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.Text = "© 2026 Patrick CH.";
            // 
            // TabControl1
            // 
            this.TabControl1.Controls.Add(this.TabPageSetup);
            this.TabControl1.Controls.Add(this.TabPageMatches);
            this.TabControl1.Controls.Add(this.TabPageRankings);
            this.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl1.Location = new System.Drawing.Point(0, 0);
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.Size = new System.Drawing.Size(1000, 631);
            this.TabControl1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 631);
            this.Controls.Add(this.TabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Tournoi de Tennis de Table - Round Robin par Tours";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ContextMenuStripPlayer.ResumeLayout(false);
            this.TabPageRankings.ResumeLayout(false);
            this.TabPageRankings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewRankings)).EndInit();
            this.TabPageMatches.ResumeLayout(false);
            this.TabPageMatches.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewMatches)).EndInit();
            this.TabPageSetup.ResumeLayout(false);
            this.TabPageSetup.PerformLayout();
            this.GroupBoxTournamentInfo.ResumeLayout(false);
            this.GroupBoxTournamentInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ToolStripStatusLableCopyright.ResumeLayout(false);
            this.ToolStripStatusLableCopyright.PerformLayout();
            this.TabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        // private System.Windows.Forms.DataGridViewTextBoxColumn ColMatch;
        // private System.Windows.Forms.DataGridViewTextBoxColumn ColJoueur1;
        // private System.Windows.Forms.DataGridViewTextBoxColumn ColVS;
        // private System.Windows.Forms.DataGridViewTextBoxColumn ColJoueur2;
        // private System.Windows.Forms.DataGridViewTextBoxColumn ColResultat;
        private System.Windows.Forms.ContextMenuStrip ContextMenuStripPlayer;
        private System.Windows.Forms.ToolStripMenuItem MenuItemAbandon;
        private TabPage TabPageRankings;
        private DataGridView DataGridViewRankings;
        private Label Label2;
        private TabPage TabPageMatches;
        private Label LabelMatchHelp;
        private Button BtnNextRound;
        private Button BtnPreviousRound;
        private Label Label5;
        private ComboBox ComboBoxRound;
        private DataGridView DataGridViewMatches;
        private TabPage TabPageSetup;
        private StatusStrip ToolStripStatusLableCopyright;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private PictureBox pictureBox1;
        private Button BtnCheckAll;
        private Button BtnUncheckAll;
        private Button BtnLoadFromFile;
        private GroupBox GroupBoxTournamentInfo;
        private Label LabelDurationPerRound5Sets;
        private Label LabelDurationPerRound3Sets;
        private Label LabelDuration5Sets;
        private Label LabelDuration3Sets;
        private Label LabelTotalRounds;
        private Label LabelTotalMatches;
        private Button BtnResetTournament;
        private Button BtnGenerateMatches;
        private Button BtnAddPlayer;
        private TextBox TxtPlayerName;
        private CheckedListBox ListBoxPlayers;
        private Label Label1;
        private TabControl TabControl1;
    }
}

