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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ContextMenuStripPlayer = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuItemAbandon = new System.Windows.Forms.ToolStripMenuItem();
            this.TabPageRankings = new System.Windows.Forms.TabPage();
            this.DataGridViewRankings = new System.Windows.Forms.DataGridView();
            this.Label2 = new System.Windows.Forms.Label();
            this.TabPageMatches = new System.Windows.Forms.TabPage();
            this.LabelMatchHelp = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.ComboBoxRound = new System.Windows.Forms.ComboBox();
            this.DataGridViewMatches = new System.Windows.Forms.DataGridView();
            this.ColMatch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColJoueur1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColVS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColJoueur2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColResultat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnNextRound = new System.Windows.Forms.Button();
            this.BtnPreviousRound = new System.Windows.Forms.Button();
            this.TabPageSetup = new System.Windows.Forms.TabPage();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolStripStatusLabelCopyright = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.BtnCheckAll = new System.Windows.Forms.Button();
            this.BtnUncheckAll = new System.Windows.Forms.Button();
            this.BtnLoadFromFile = new System.Windows.Forms.Button();
            this.GroupBoxTournamentInfo = new System.Windows.Forms.GroupBox();
            this.LabelDurationPerRound5Sets = new System.Windows.Forms.Label();
            this.LabelDurationPerRound3Sets = new System.Windows.Forms.Label();
            this.LabelDuration5Sets = new System.Windows.Forms.Label();
            this.LabelDuration3Sets = new System.Windows.Forms.Label();
            this.LabelTotalRounds = new System.Windows.Forms.Label();
            this.LabelTotalMatches = new System.Windows.Forms.Label();
            this.BtnResetTournament = new System.Windows.Forms.Button();
            this.BtnGenerateMatches = new System.Windows.Forms.Button();
            this.BtnAddPlayer = new System.Windows.Forms.Button();
            this.TxtPlayerName = new System.Windows.Forms.TextBox();
            this.ListBoxAllPlayers = new System.Windows.Forms.ListBox();
            this.ListBoxPresentPlayers = new System.Windows.Forms.ListBox();
            this.TxtFilterPlayers = new System.Windows.Forms.TextBox();
            this.BtnClearFilter = new System.Windows.Forms.Button();
            this.LabelAllPlayers = new System.Windows.Forms.Label();
            this.LabelPresentPlayers = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.ContextMenuStripPlayer.SuspendLayout();
            this.TabPageRankings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewRankings)).BeginInit();
            this.TabPageMatches.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewMatches)).BeginInit();
            this.TabPageSetup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            this.toolStripStatusLabelCopyright.SuspendLayout();
            this.GroupBoxTournamentInfo.SuspendLayout();
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
            this.TabPageRankings.Location = new System.Drawing.Point(4, 25);
            this.TabPageRankings.Name = "TabPageRankings";
            this.TabPageRankings.Size = new System.Drawing.Size(1008, 680);
            this.TabPageRankings.TabIndex = 2;
            this.TabPageRankings.Text = "Classement";
            this.TabPageRankings.UseVisualStyleBackColor = true;
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
            this.DataGridViewRankings.Size = new System.Drawing.Size(950, 611);
            this.DataGridViewRankings.TabIndex = 1;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(16, 20);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(118, 24);
            this.Label2.TabIndex = 0;
            this.Label2.Text = "Classement";
            // 
            // TabPageMatches
            // 
            this.TabPageMatches.Controls.Add(this.LabelMatchHelp);
            this.TabPageMatches.Controls.Add(this.Label5);
            this.TabPageMatches.Controls.Add(this.ComboBoxRound);
            this.TabPageMatches.Controls.Add(this.DataGridViewMatches);
            this.TabPageMatches.Controls.Add(this.BtnNextRound);
            this.TabPageMatches.Controls.Add(this.BtnPreviousRound);
            this.TabPageMatches.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabPageMatches.Location = new System.Drawing.Point(4, 25);
            this.TabPageMatches.Name = "TabPageMatches";
            this.TabPageMatches.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageMatches.Size = new System.Drawing.Size(1008, 680);
            this.TabPageMatches.TabIndex = 1;
            this.TabPageMatches.Text = "Matchs";
            this.TabPageMatches.UseVisualStyleBackColor = true;
            // 
            // LabelMatchHelp
            // 
            this.LabelMatchHelp.AutoSize = true;
            this.LabelMatchHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelMatchHelp.Location = new System.Drawing.Point(163, 600);
            this.LabelMatchHelp.Name = "LabelMatchHelp";
            this.LabelMatchHelp.Size = new System.Drawing.Size(553, 64);
            this.LabelMatchHelp.TabIndex = 10;
            this.LabelMatchHelp.Text = resources.GetString("LabelMatchHelp.Text");
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.Location = new System.Drawing.Point(17, 29);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(50, 20);
            this.Label5.TabIndex = 7;
            this.Label5.Text = "Tour:";
            // 
            // ComboBoxRound
            // 
            this.ComboBoxRound.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxRound.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboBoxRound.FormattingEnabled = true;
            this.ComboBoxRound.Location = new System.Drawing.Point(166, 25);
            this.ComboBoxRound.Name = "ComboBoxRound";
            this.ComboBoxRound.Size = new System.Drawing.Size(150, 28);
            this.ComboBoxRound.TabIndex = 6;
            this.ComboBoxRound.SelectedIndexChanged += new System.EventHandler(this.ComboBoxRound_SelectedIndexChanged);
            // 
            // DataGridViewMatches
            // 
            this.DataGridViewMatches.AllowUserToAddRows = false;
            this.DataGridViewMatches.AllowUserToDeleteRows = false;
            this.DataGridViewMatches.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewMatches.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColMatch,
            this.ColJoueur1,
            this.ColVS,
            this.ColJoueur2,
            this.ColResultat});
            this.DataGridViewMatches.Location = new System.Drawing.Point(6, 72);
            this.DataGridViewMatches.MultiSelect = false;
            this.DataGridViewMatches.Name = "DataGridViewMatches";
            this.DataGridViewMatches.ReadOnly = true;
            this.DataGridViewMatches.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridViewMatches.Size = new System.Drawing.Size(1013, 512);
            this.DataGridViewMatches.TabIndex = 0;
            this.DataGridViewMatches.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewMatches_CellDoubleClick);
            this.DataGridViewMatches.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridViewMatches_CellMouseDown);
            // 
            // ColMatch
            // 
            this.ColMatch.DataPropertyName = "Match";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColMatch.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColMatch.Frozen = true;
            this.ColMatch.HeaderText = "Match";
            this.ColMatch.Name = "ColMatch";
            this.ColMatch.ReadOnly = true;
            this.ColMatch.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColMatch.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.ColMatch.Width = 80;
            // 
            // ColJoueur1
            // 
            this.ColJoueur1.DataPropertyName = "Joueur1";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.ColJoueur1.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColJoueur1.Frozen = true;
            this.ColJoueur1.HeaderText = "Joueur1";
            this.ColJoueur1.Name = "ColJoueur1";
            this.ColJoueur1.ReadOnly = true;
            this.ColJoueur1.Width = 280;
            // 
            // ColVS
            // 
            this.ColVS.DataPropertyName = "VS";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColVS.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColVS.Frozen = true;
            this.ColVS.HeaderText = "VS";
            this.ColVS.Name = "ColVS";
            this.ColVS.ReadOnly = true;
            this.ColVS.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColVS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColVS.Width = 40;
            // 
            // ColJoueur2
            // 
            this.ColJoueur2.DataPropertyName = "Joueur2";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColJoueur2.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColJoueur2.Frozen = true;
            this.ColJoueur2.HeaderText = "Joueur2";
            this.ColJoueur2.Name = "ColJoueur2";
            this.ColJoueur2.ReadOnly = true;
            this.ColJoueur2.Width = 280;
            // 
            // ColResultat
            // 
            this.ColResultat.DataPropertyName = "Resultat";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.ColResultat.DefaultCellStyle = dataGridViewCellStyle5;
            this.ColResultat.Frozen = true;
            this.ColResultat.HeaderText = "Résultat";
            this.ColResultat.Name = "ColResultat";
            this.ColResultat.ReadOnly = true;
            this.ColResultat.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColResultat.Width = 280;
            // 
            // BtnNextRound
            // 
            this.BtnNextRound.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.BtnNextRound.Image = global::RoundRobin.Properties.Resources.Fleche_Droite_64;
            this.BtnNextRound.Location = new System.Drawing.Point(322, 12);
            this.BtnNextRound.Name = "BtnNextRound";
            this.BtnNextRound.Size = new System.Drawing.Size(74, 54);
            this.BtnNextRound.TabIndex = 9;
            this.BtnNextRound.UseVisualStyleBackColor = true;
            this.BtnNextRound.Click += new System.EventHandler(this.BtnNextRound_Click);
            // 
            // BtnPreviousRound
            // 
            this.BtnPreviousRound.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.BtnPreviousRound.Image = global::RoundRobin.Properties.Resources.Fleche_Gauche_64;
            this.BtnPreviousRound.Location = new System.Drawing.Point(86, 13);
            this.BtnPreviousRound.Name = "BtnPreviousRound";
            this.BtnPreviousRound.Size = new System.Drawing.Size(74, 54);
            this.BtnPreviousRound.TabIndex = 8;
            this.BtnPreviousRound.UseVisualStyleBackColor = true;
            this.BtnPreviousRound.Click += new System.EventHandler(this.BtnPreviousRound_Click);
            // 
            // TabPageSetup
            // 
            this.TabPageSetup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.TabPageSetup.Controls.Add(this.PictureBox1);
            this.TabPageSetup.Controls.Add(this.toolStripStatusLabelCopyright);
            this.TabPageSetup.Controls.Add(this.BtnCheckAll);
            this.TabPageSetup.Controls.Add(this.BtnUncheckAll);
            this.TabPageSetup.Controls.Add(this.BtnLoadFromFile);
            this.TabPageSetup.Controls.Add(this.GroupBoxTournamentInfo);
            this.TabPageSetup.Controls.Add(this.BtnResetTournament);
            this.TabPageSetup.Controls.Add(this.BtnGenerateMatches);
            this.TabPageSetup.Controls.Add(this.BtnAddPlayer);
            this.TabPageSetup.Controls.Add(this.TxtPlayerName);
            this.TabPageSetup.Controls.Add(this.ListBoxAllPlayers);
            this.TabPageSetup.Controls.Add(this.ListBoxPresentPlayers);
            this.TabPageSetup.Controls.Add(this.TxtFilterPlayers);
            this.TabPageSetup.Controls.Add(this.BtnClearFilter);
            this.TabPageSetup.Controls.Add(this.LabelAllPlayers);
            this.TabPageSetup.Controls.Add(this.LabelPresentPlayers);
            this.TabPageSetup.Controls.Add(this.Label1);
            this.TabPageSetup.Location = new System.Drawing.Point(4, 25);
            this.TabPageSetup.Name = "TabPageSetup";
            this.TabPageSetup.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageSetup.Size = new System.Drawing.Size(1008, 680);
            this.TabPageSetup.TabIndex = 0;
            this.TabPageSetup.Text = "Configuration";
            this.TabPageSetup.UseVisualStyleBackColor = true;
            // 
            // PictureBox1
            // 
            this.PictureBox1.Image = global::RoundRobin.Properties.Resources.Logo1;
            this.PictureBox1.Location = new System.Drawing.Point(861, 0);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(122, 122);
            this.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBox1.TabIndex = 15;
            this.PictureBox1.TabStop = false;
            // 
            // toolStripStatusLabelCopyright
            // 
            this.toolStripStatusLabelCopyright.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.toolStripStatusLabelCopyright.Location = new System.Drawing.Point(3, 655);
            this.toolStripStatusLabelCopyright.Name = "toolStripStatusLabelCopyright";
            this.toolStripStatusLabelCopyright.Size = new System.Drawing.Size(1002, 22);
            this.toolStripStatusLabelCopyright.TabIndex = 11;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(987, 17);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.Text = "© 2026 Patrick CH. - V1.0";
            // 
            // BtnCheckAll
            // 
            this.BtnCheckAll.Image = global::RoundRobin.Properties.Resources.tout_cocher_64;
            this.BtnCheckAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCheckAll.Location = new System.Drawing.Point(412, 362);
            this.BtnCheckAll.Name = "BtnCheckAll";
            this.BtnCheckAll.Size = new System.Drawing.Size(150, 76);
            this.BtnCheckAll.TabIndex = 8;
            this.BtnCheckAll.Text = "Tout &ajouter";
            this.BtnCheckAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnCheckAll.UseVisualStyleBackColor = true;
            this.BtnCheckAll.Click += new System.EventHandler(this.BtnCheckAll_Click);
            // 
            // BtnUncheckAll
            // 
            this.BtnUncheckAll.Image = global::RoundRobin.Properties.Resources.tout_decocher_64;
            this.BtnUncheckAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnUncheckAll.Location = new System.Drawing.Point(412, 453);
            this.BtnUncheckAll.Name = "BtnUncheckAll";
            this.BtnUncheckAll.Size = new System.Drawing.Size(150, 76);
            this.BtnUncheckAll.TabIndex = 9;
            this.BtnUncheckAll.Text = "Tout &retirer";
            this.BtnUncheckAll.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnUncheckAll.UseVisualStyleBackColor = true;
            this.BtnUncheckAll.Click += new System.EventHandler(this.BtnUncheckAll_Click);
            // 
            // BtnLoadFromFile
            // 
            this.BtnLoadFromFile.Image = global::RoundRobin.Properties.Resources.Directory_64;
            this.BtnLoadFromFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnLoadFromFile.Location = new System.Drawing.Point(401, 6);
            this.BtnLoadFromFile.Name = "BtnLoadFromFile";
            this.BtnLoadFromFile.Size = new System.Drawing.Size(191, 76);
            this.BtnLoadFromFile.TabIndex = 7;
            this.BtnLoadFromFile.Text = "Charger un &fichier";
            this.BtnLoadFromFile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnLoadFromFile.UseVisualStyleBackColor = true;
            this.BtnLoadFromFile.Click += new System.EventHandler(this.BtnLoadFromFile_Click);
            // 
            // GroupBoxTournamentInfo
            // 
            this.GroupBoxTournamentInfo.Controls.Add(this.LabelDurationPerRound5Sets);
            this.GroupBoxTournamentInfo.Controls.Add(this.LabelDurationPerRound3Sets);
            this.GroupBoxTournamentInfo.Controls.Add(this.LabelDuration5Sets);
            this.GroupBoxTournamentInfo.Controls.Add(this.LabelDuration3Sets);
            this.GroupBoxTournamentInfo.Controls.Add(this.LabelTotalRounds);
            this.GroupBoxTournamentInfo.Controls.Add(this.LabelTotalMatches);
            this.GroupBoxTournamentInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBoxTournamentInfo.Location = new System.Drawing.Point(374, 100);
            this.GroupBoxTournamentInfo.Name = "GroupBoxTournamentInfo";
            this.GroupBoxTournamentInfo.Size = new System.Drawing.Size(262, 220);
            this.GroupBoxTournamentInfo.TabIndex = 6;
            this.GroupBoxTournamentInfo.TabStop = false;
            this.GroupBoxTournamentInfo.Text = "📊 Informations sur le tournoi";
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
            // BtnResetTournament
            // 
            this.BtnResetTournament.Image = global::RoundRobin.Properties.Resources.Corbeille_64;
            this.BtnResetTournament.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnResetTournament.Location = new System.Drawing.Point(20, 559);
            this.BtnResetTournament.Name = "BtnResetTournament";
            this.BtnResetTournament.Size = new System.Drawing.Size(321, 76);
            this.BtnResetTournament.TabIndex = 5;
            this.BtnResetTournament.Text = "&Réinitialiser le tournoi";
            this.BtnResetTournament.UseVisualStyleBackColor = true;
            this.BtnResetTournament.Click += new System.EventHandler(this.BtnResetTournament_Click);
            // 
            // BtnGenerateMatches
            // 
            this.BtnGenerateMatches.Enabled = false;
            this.BtnGenerateMatches.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.BtnGenerateMatches.Image = global::RoundRobin.Properties.Resources.Go_64;
            this.BtnGenerateMatches.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnGenerateMatches.Location = new System.Drawing.Point(664, 559);
            this.BtnGenerateMatches.Name = "BtnGenerateMatches";
            this.BtnGenerateMatches.Size = new System.Drawing.Size(321, 76);
            this.BtnGenerateMatches.TabIndex = 4;
            this.BtnGenerateMatches.Text = "&Générer les matchs par tour";
            this.BtnGenerateMatches.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnGenerateMatches.UseVisualStyleBackColor = true;
            this.BtnGenerateMatches.Click += new System.EventHandler(this.BtnGenerateMatches_Click);
            // 
            // BtnAddPlayer
            // 
            this.BtnAddPlayer.Image = global::RoundRobin.Properties.Resources.Ajouter_64;
            this.BtnAddPlayer.Location = new System.Drawing.Point(245, 6);
            this.BtnAddPlayer.Name = "BtnAddPlayer";
            this.BtnAddPlayer.Size = new System.Drawing.Size(96, 76);
            this.BtnAddPlayer.TabIndex = 3;
            this.BtnAddPlayer.Text = "&Ajouter";
            this.BtnAddPlayer.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnAddPlayer.UseVisualStyleBackColor = true;
            this.BtnAddPlayer.Click += new System.EventHandler(this.BtnAddPlayer_Click);
            // 
            // TxtPlayerName
            // 
            this.TxtPlayerName.Location = new System.Drawing.Point(20, 38);
            this.TxtPlayerName.Name = "TxtPlayerName";
            this.TxtPlayerName.Size = new System.Drawing.Size(207, 22);
            this.TxtPlayerName.TabIndex = 2;
            // 
            // ListBoxAllPlayers
            // 
            this.ListBoxAllPlayers.AllowDrop = true;
            this.ListBoxAllPlayers.FormattingEnabled = true;
            this.ListBoxAllPlayers.ItemHeight = 16;
            this.ListBoxAllPlayers.Location = new System.Drawing.Point(20, 125);
            this.ListBoxAllPlayers.Name = "ListBoxAllPlayers";
            this.ListBoxAllPlayers.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.ListBoxAllPlayers.Size = new System.Drawing.Size(321, 404);
            this.ListBoxAllPlayers.TabIndex = 13;
            this.ListBoxAllPlayers.DragDrop += new System.Windows.Forms.DragEventHandler(this.ListBoxAllPlayers_DragDrop);
            this.ListBoxAllPlayers.DragEnter += new System.Windows.Forms.DragEventHandler(this.ListBoxAllPlayers_DragEnter);
            this.ListBoxAllPlayers.DoubleClick += new System.EventHandler(this.ListBoxAllPlayers_DoubleClick);
            this.ListBoxAllPlayers.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ListBoxAllPlayers_MouseDown);
            // 
            // ListBoxPresentPlayers
            // 
            this.ListBoxPresentPlayers.AllowDrop = true;
            this.ListBoxPresentPlayers.FormattingEnabled = true;
            this.ListBoxPresentPlayers.ItemHeight = 16;
            this.ListBoxPresentPlayers.Location = new System.Drawing.Point(664, 125);
            this.ListBoxPresentPlayers.Name = "ListBoxPresentPlayers";
            this.ListBoxPresentPlayers.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.ListBoxPresentPlayers.Size = new System.Drawing.Size(321, 404);
            this.ListBoxPresentPlayers.TabIndex = 14;
            this.ListBoxPresentPlayers.DragDrop += new System.Windows.Forms.DragEventHandler(this.ListBoxPresentPlayers_DragDrop);
            this.ListBoxPresentPlayers.DragEnter += new System.Windows.Forms.DragEventHandler(this.ListBoxPresentPlayers_DragEnter);
            this.ListBoxPresentPlayers.DoubleClick += new System.EventHandler(this.ListBoxPresentPlayers_DoubleClick);
            this.ListBoxPresentPlayers.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ListBoxPresentPlayers_MouseDown);
            // 
            // TxtFilterPlayers
            // 
            this.TxtFilterPlayers.Location = new System.Drawing.Point(20, 100);
            this.TxtFilterPlayers.Name = "TxtFilterPlayers";
            this.TxtFilterPlayers.Size = new System.Drawing.Size(280, 22);
            this.TxtFilterPlayers.TabIndex = 10;
            this.TxtFilterPlayers.TextChanged += new System.EventHandler(this.TxtFilterPlayers_TextChanged);
            // 
            // BtnClearFilter
            // 
            this.BtnClearFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnClearFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.BtnClearFilter.Image = global::RoundRobin.Properties.Resources.gomme;
            this.BtnClearFilter.Location = new System.Drawing.Point(305, 98);
            this.BtnClearFilter.Name = "BtnClearFilter";
            this.BtnClearFilter.Size = new System.Drawing.Size(36, 26);
            this.BtnClearFilter.TabIndex = 15;
            this.BtnClearFilter.UseVisualStyleBackColor = true;
            this.BtnClearFilter.Click += new System.EventHandler(this.BtnClearFilter_Click);
            // 
            // LabelAllPlayers
            // 
            this.LabelAllPlayers.AutoSize = true;
            this.LabelAllPlayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.LabelAllPlayers.Location = new System.Drawing.Point(17, 82);
            this.LabelAllPlayers.Name = "LabelAllPlayers";
            this.LabelAllPlayers.Size = new System.Drawing.Size(120, 15);
            this.LabelAllPlayers.TabIndex = 11;
            this.LabelAllPlayers.Text = "Filtre sur le nom :";
            // 
            // LabelPresentPlayers
            // 
            this.LabelPresentPlayers.AutoSize = true;
            this.LabelPresentPlayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelPresentPlayers.Location = new System.Drawing.Point(660, 102);
            this.LabelPresentPlayers.Name = "LabelPresentPlayers";
            this.LabelPresentPlayers.Size = new System.Drawing.Size(153, 20);
            this.LabelPresentPlayers.TabIndex = 12;
            this.LabelPresentPlayers.Text = "Joueurs présents:";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.Label1.Location = new System.Drawing.Point(17, 15);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(62, 15);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Joueurs:";
            // 
            // TabControl1
            // 
            this.TabControl1.Controls.Add(this.TabPageSetup);
            this.TabControl1.Controls.Add(this.TabPageMatches);
            this.TabControl1.Controls.Add(this.TabPageRankings);
            this.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabControl1.Location = new System.Drawing.Point(0, 0);
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.Size = new System.Drawing.Size(1016, 709);
            this.TabControl1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 709);
            this.Controls.Add(this.TabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Tournoi de Tennis de Table - Simple Round Robin par Tours";
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
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            this.toolStripStatusLabelCopyright.ResumeLayout(false);
            this.toolStripStatusLabelCopyright.PerformLayout();
            this.GroupBoxTournamentInfo.ResumeLayout(false);
            this.GroupBoxTournamentInfo.PerformLayout();
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
        private StatusStrip toolStripStatusLabelCopyright;
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
        private Label Label1;
        private TabControl TabControl1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private DataGridViewTextBoxColumn ColMatch;
        private DataGridViewTextBoxColumn ColJoueur1;
        private DataGridViewTextBoxColumn ColVS;
        private DataGridViewTextBoxColumn ColJoueur2;
        private DataGridViewTextBoxColumn ColResultat;
        private TextBox TxtFilterPlayers;
        private Button BtnClearFilter;
        private Label LabelAllPlayers;
        private Label LabelPresentPlayers;
        private ListBox ListBoxAllPlayers;
        private ListBox ListBoxPresentPlayers;
        private PictureBox PictureBox1;
    }
}

