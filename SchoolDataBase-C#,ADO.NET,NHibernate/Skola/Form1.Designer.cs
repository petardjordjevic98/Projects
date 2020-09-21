namespace Skola
{
    partial class Form1
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
            this.cmdPrikazivanjeUcenika = new System.Windows.Forms.Button();
            this.cmdDodavanjeUcenika = new System.Windows.Forms.Button();
            this.cmdPrikazivanjeOcene = new System.Windows.Forms.Button();
            this.cmdOneToManyUcenikOcena = new System.Windows.Forms.Button();
            this.cmdManyToOneUcenikOcena = new System.Windows.Forms.Button();
            this.cmdDodavanjeSmera = new System.Windows.Forms.Button();
            this.cmdPrikazivanjePredmeta = new System.Windows.Forms.Button();
            this.cmdManyToOneUcenikSmer = new System.Windows.Forms.Button();
            this.cmdDodavanjeUcenikaNaSmer = new System.Windows.Forms.Button();
            this.cmdOneToManyPredmetOcene = new System.Windows.Forms.Button();
            this.cmdDodavanjeRoditelja = new System.Windows.Forms.Button();
            this.cmd_ManyToManyPredmetSmer = new System.Windows.Forms.Button();
            this.cmdPrikaziZaposlenog = new System.Windows.Forms.Button();
            this.cmdManyToManyNastavnikPredmet = new System.Windows.Forms.Button();
            this.Godine = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmdDodavanjeOceneUceniku = new System.Windows.Forms.Button();
            this.cmdAzuriranjeUcenika = new System.Windows.Forms.Button();
            this.cmdBrisanjeUcenika = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmdAzuriranjeOcene = new System.Windows.Forms.Button();
            this.cmdBrisanjeOcene = new System.Windows.Forms.Button();
            this.cmdDodavanjeOcene = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cmdAzuriranjeSmera = new System.Windows.Forms.Button();
            this.cmdBrisanjeSmera = new System.Windows.Forms.Button();
            this.cmdPrikazivanjeSmera = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cmdDodavanjeOcenePredmetu = new System.Windows.Forms.Button();
            this.cmdBrisanjePredmeta = new System.Windows.Forms.Button();
            this.cmdDodavanjePredmeta = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cmdDodavanjeNenastavnog = new System.Windows.Forms.Button();
            this.cmdVisevrednosniAdresa = new System.Windows.Forms.Button();
            this.cmdVisevrednosniSkole = new System.Windows.Forms.Button();
            this.cmdDodavanjeNastavnogPN = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.cmdAzuriranjeRoditelja = new System.Windows.Forms.Button();
            this.cmdBrisanjeRoditelja = new System.Windows.Forms.Button();
            this.cmdPrikazivanjeRoditelja = new System.Windows.Forms.Button();
            this.cmdOneToManyUcenikSmer = new System.Windows.Forms.Button();
            this.cmdManyToOnePredmetOcene = new System.Windows.Forms.Button();
            this.cmdAzuriranjePredmeta = new System.Windows.Forms.Button();
            this.cmdDodavanjeNastavnogBN = new System.Windows.Forms.Button();
            this.cmdBrisanjeZaposlenog = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdPrikazivanjeUcenika
            // 
            this.cmdPrikazivanjeUcenika.Location = new System.Drawing.Point(5, 20);
            this.cmdPrikazivanjeUcenika.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdPrikazivanjeUcenika.Name = "cmdPrikazivanjeUcenika";
            this.cmdPrikazivanjeUcenika.Size = new System.Drawing.Size(228, 23);
            this.cmdPrikazivanjeUcenika.TabIndex = 0;
            this.cmdPrikazivanjeUcenika.Text = "Prikazivanje Ucenika";
            this.cmdPrikazivanjeUcenika.UseVisualStyleBackColor = true;
            this.cmdPrikazivanjeUcenika.Click += new System.EventHandler(this.cmdPrikazivanjeUcenika_Click);
            // 
            // cmdDodavanjeUcenika
            // 
            this.cmdDodavanjeUcenika.Location = new System.Drawing.Point(5, 47);
            this.cmdDodavanjeUcenika.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdDodavanjeUcenika.Name = "cmdDodavanjeUcenika";
            this.cmdDodavanjeUcenika.Size = new System.Drawing.Size(228, 23);
            this.cmdDodavanjeUcenika.TabIndex = 1;
            this.cmdDodavanjeUcenika.Text = "Dodavanje ucenika";
            this.cmdDodavanjeUcenika.UseVisualStyleBackColor = true;
            this.cmdDodavanjeUcenika.Click += new System.EventHandler(this.cmdDodavanjeUcenika_Click);
            // 
            // cmdPrikazivanjeOcene
            // 
            this.cmdPrikazivanjeOcene.Location = new System.Drawing.Point(5, 20);
            this.cmdPrikazivanjeOcene.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdPrikazivanjeOcene.Name = "cmdPrikazivanjeOcene";
            this.cmdPrikazivanjeOcene.Size = new System.Drawing.Size(228, 23);
            this.cmdPrikazivanjeOcene.TabIndex = 2;
            this.cmdPrikazivanjeOcene.Text = "Prikazivanje ocene";
            this.cmdPrikazivanjeOcene.UseVisualStyleBackColor = true;
            this.cmdPrikazivanjeOcene.Click += new System.EventHandler(this.cmdPrikazivanjeOcene_Click);
            // 
            // cmdOneToManyUcenikOcena
            // 
            this.cmdOneToManyUcenikOcena.Location = new System.Drawing.Point(69, 143);
            this.cmdOneToManyUcenikOcena.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdOneToManyUcenikOcena.Name = "cmdOneToManyUcenikOcena";
            this.cmdOneToManyUcenikOcena.Size = new System.Drawing.Size(228, 23);
            this.cmdOneToManyUcenikOcena.TabIndex = 3;
            this.cmdOneToManyUcenikOcena.Text = "One-to-Many Ucenik Ocena";
            this.cmdOneToManyUcenikOcena.UseVisualStyleBackColor = true;
            this.cmdOneToManyUcenikOcena.Click += new System.EventHandler(this.cmdOneToManyUcenikOcena_Click);
            // 
            // cmdManyToOneUcenikOcena
            // 
            this.cmdManyToOneUcenikOcena.Location = new System.Drawing.Point(69, 170);
            this.cmdManyToOneUcenikOcena.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdManyToOneUcenikOcena.Name = "cmdManyToOneUcenikOcena";
            this.cmdManyToOneUcenikOcena.Size = new System.Drawing.Size(228, 23);
            this.cmdManyToOneUcenikOcena.TabIndex = 4;
            this.cmdManyToOneUcenikOcena.Text = "Many-To-One Ucenik Ocena";
            this.cmdManyToOneUcenikOcena.UseVisualStyleBackColor = true;
            this.cmdManyToOneUcenikOcena.Click += new System.EventHandler(this.cmdManyToOneUcenikOcena_Click);
            // 
            // cmdDodavanjeSmera
            // 
            this.cmdDodavanjeSmera.Location = new System.Drawing.Point(5, 48);
            this.cmdDodavanjeSmera.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdDodavanjeSmera.Name = "cmdDodavanjeSmera";
            this.cmdDodavanjeSmera.Size = new System.Drawing.Size(228, 23);
            this.cmdDodavanjeSmera.TabIndex = 5;
            this.cmdDodavanjeSmera.Text = "Dodavanje smera";
            this.cmdDodavanjeSmera.UseVisualStyleBackColor = true;
            this.cmdDodavanjeSmera.Click += new System.EventHandler(this.cmdDodavanjeSmera_Click);
            // 
            // cmdPrikazivanjePredmeta
            // 
            this.cmdPrikazivanjePredmeta.Location = new System.Drawing.Point(5, 30);
            this.cmdPrikazivanjePredmeta.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdPrikazivanjePredmeta.Name = "cmdPrikazivanjePredmeta";
            this.cmdPrikazivanjePredmeta.Size = new System.Drawing.Size(231, 23);
            this.cmdPrikazivanjePredmeta.TabIndex = 6;
            this.cmdPrikazivanjePredmeta.Text = "Prikazivanje predmeta";
            this.cmdPrikazivanjePredmeta.UseVisualStyleBackColor = true;
            this.cmdPrikazivanjePredmeta.Click += new System.EventHandler(this.cmdPrikazivanjePredmeta_Click);
            // 
            // cmdManyToOneUcenikSmer
            // 
            this.cmdManyToOneUcenikSmer.Location = new System.Drawing.Point(428, 50);
            this.cmdManyToOneUcenikSmer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdManyToOneUcenikSmer.Name = "cmdManyToOneUcenikSmer";
            this.cmdManyToOneUcenikSmer.Size = new System.Drawing.Size(228, 23);
            this.cmdManyToOneUcenikSmer.TabIndex = 7;
            this.cmdManyToOneUcenikSmer.Text = "Many-to-One Ucenik Smer";
            this.cmdManyToOneUcenikSmer.UseVisualStyleBackColor = true;
            this.cmdManyToOneUcenikSmer.Click += new System.EventHandler(this.cmdManyToOneUcenikSmer_Click);
            // 
            // cmdDodavanjeUcenikaNaSmer
            // 
            this.cmdDodavanjeUcenikaNaSmer.Location = new System.Drawing.Point(245, 20);
            this.cmdDodavanjeUcenikaNaSmer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdDodavanjeUcenikaNaSmer.Name = "cmdDodavanjeUcenikaNaSmer";
            this.cmdDodavanjeUcenikaNaSmer.Size = new System.Drawing.Size(228, 23);
            this.cmdDodavanjeUcenikaNaSmer.TabIndex = 8;
            this.cmdDodavanjeUcenikaNaSmer.Text = "Dodavanje ucenika na smer";
            this.cmdDodavanjeUcenikaNaSmer.UseVisualStyleBackColor = true;
            this.cmdDodavanjeUcenikaNaSmer.Click += new System.EventHandler(this.cmdDodavanjeUcenikaNaSmer_Click);
            // 
            // cmdOneToManyPredmetOcene
            // 
            this.cmdOneToManyPredmetOcene.Location = new System.Drawing.Point(437, 234);
            this.cmdOneToManyPredmetOcene.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdOneToManyPredmetOcene.Name = "cmdOneToManyPredmetOcene";
            this.cmdOneToManyPredmetOcene.Size = new System.Drawing.Size(228, 23);
            this.cmdOneToManyPredmetOcene.TabIndex = 9;
            this.cmdOneToManyPredmetOcene.Text = "One-to-Many Predmet Ocene";
            this.cmdOneToManyPredmetOcene.UseVisualStyleBackColor = true;
            this.cmdOneToManyPredmetOcene.Click += new System.EventHandler(this.cmdOneToManyPredmetOcene_Click);
            // 
            // cmdDodavanjeRoditelja
            // 
            this.cmdDodavanjeRoditelja.Location = new System.Drawing.Point(0, 49);
            this.cmdDodavanjeRoditelja.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdDodavanjeRoditelja.Name = "cmdDodavanjeRoditelja";
            this.cmdDodavanjeRoditelja.Size = new System.Drawing.Size(231, 23);
            this.cmdDodavanjeRoditelja.TabIndex = 10;
            this.cmdDodavanjeRoditelja.Text = "Dodavanje roditelja";
            this.cmdDodavanjeRoditelja.UseVisualStyleBackColor = true;
            this.cmdDodavanjeRoditelja.Click += new System.EventHandler(this.cmdDodavanjeRoditelja_Click);
            // 
            // cmd_ManyToManyPredmetSmer
            // 
            this.cmd_ManyToManyPredmetSmer.Location = new System.Drawing.Point(805, 161);
            this.cmd_ManyToManyPredmetSmer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmd_ManyToManyPredmetSmer.Name = "cmd_ManyToManyPredmetSmer";
            this.cmd_ManyToManyPredmetSmer.Size = new System.Drawing.Size(231, 23);
            this.cmd_ManyToManyPredmetSmer.TabIndex = 12;
            this.cmd_ManyToManyPredmetSmer.Text = "Many-To-Many Predmet Smer";
            this.cmd_ManyToManyPredmetSmer.UseVisualStyleBackColor = true;
            this.cmd_ManyToManyPredmetSmer.Click += new System.EventHandler(this.cmd_ManyToManyPredmetSmer_Click);
            // 
            // cmdPrikaziZaposlenog
            // 
            this.cmdPrikaziZaposlenog.Location = new System.Drawing.Point(13, 47);
            this.cmdPrikaziZaposlenog.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdPrikaziZaposlenog.Name = "cmdPrikaziZaposlenog";
            this.cmdPrikaziZaposlenog.Size = new System.Drawing.Size(231, 23);
            this.cmdPrikaziZaposlenog.TabIndex = 13;
            this.cmdPrikaziZaposlenog.Text = "Prikazi zaposlenog";
            this.cmdPrikaziZaposlenog.UseVisualStyleBackColor = true;
            this.cmdPrikaziZaposlenog.Click += new System.EventHandler(this.cmdPrikaziZaposlenog_Click);
            // 
            // cmdManyToManyNastavnikPredmet
            // 
            this.cmdManyToManyNastavnikPredmet.Location = new System.Drawing.Point(795, 355);
            this.cmdManyToManyNastavnikPredmet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdManyToManyNastavnikPredmet.Name = "cmdManyToManyNastavnikPredmet";
            this.cmdManyToManyNastavnikPredmet.Size = new System.Drawing.Size(271, 23);
            this.cmdManyToManyNastavnikPredmet.TabIndex = 14;
            this.cmdManyToManyNastavnikPredmet.Text = "Many-To-Many Predmet Nastavnik";
            this.cmdManyToManyNastavnikPredmet.UseVisualStyleBackColor = true;
            this.cmdManyToManyNastavnikPredmet.Click += new System.EventHandler(this.cmdManyToManyNastavnikPredmet_Click);
            // 
            // Godine
            // 
            this.Godine.Location = new System.Drawing.Point(257, 30);
            this.Godine.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Godine.Name = "Godine";
            this.Godine.Size = new System.Drawing.Size(231, 23);
            this.Godine.TabIndex = 15;
            this.Godine.Text = "Visevrednosni godina";
            this.Godine.UseVisualStyleBackColor = true;
            this.Godine.Click += new System.EventHandler(this.Godine_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmdDodavanjeOceneUceniku);
            this.groupBox1.Controls.Add(this.cmdAzuriranjeUcenika);
            this.groupBox1.Controls.Add(this.cmdBrisanjeUcenika);
            this.groupBox1.Controls.Add(this.cmdPrikazivanjeUcenika);
            this.groupBox1.Controls.Add(this.cmdDodavanjeUcenika);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(401, 126);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ucenik";
            // 
            // cmdDodavanjeOceneUceniku
            // 
            this.cmdDodavanjeOceneUceniku.Location = new System.Drawing.Point(239, 21);
            this.cmdDodavanjeOceneUceniku.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdDodavanjeOceneUceniku.Name = "cmdDodavanjeOceneUceniku";
            this.cmdDodavanjeOceneUceniku.Size = new System.Drawing.Size(157, 50);
            this.cmdDodavanjeOceneUceniku.TabIndex = 9;
            this.cmdDodavanjeOceneUceniku.Text = "Dodavanje ocene uceniku";
            this.cmdDodavanjeOceneUceniku.UseVisualStyleBackColor = true;
            this.cmdDodavanjeOceneUceniku.Click += new System.EventHandler(this.cmdDodavanjeOceneUceniku_Click);
            // 
            // cmdAzuriranjeUcenika
            // 
            this.cmdAzuriranjeUcenika.Location = new System.Drawing.Point(5, 103);
            this.cmdAzuriranjeUcenika.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdAzuriranjeUcenika.Name = "cmdAzuriranjeUcenika";
            this.cmdAzuriranjeUcenika.Size = new System.Drawing.Size(228, 23);
            this.cmdAzuriranjeUcenika.TabIndex = 3;
            this.cmdAzuriranjeUcenika.Text = "Azuriranje ucenika";
            this.cmdAzuriranjeUcenika.UseVisualStyleBackColor = true;
            this.cmdAzuriranjeUcenika.Click += new System.EventHandler(this.cmdAzuriranjeUcenika_Click);
            // 
            // cmdBrisanjeUcenika
            // 
            this.cmdBrisanjeUcenika.Location = new System.Drawing.Point(5, 76);
            this.cmdBrisanjeUcenika.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdBrisanjeUcenika.Name = "cmdBrisanjeUcenika";
            this.cmdBrisanjeUcenika.Size = new System.Drawing.Size(228, 23);
            this.cmdBrisanjeUcenika.TabIndex = 2;
            this.cmdBrisanjeUcenika.Text = "Brisanje ucenika";
            this.cmdBrisanjeUcenika.UseVisualStyleBackColor = true;
            this.cmdBrisanjeUcenika.Click += new System.EventHandler(this.cmdBrisanjeUcenika_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmdAzuriranjeOcene);
            this.groupBox2.Controls.Add(this.cmdBrisanjeOcene);
            this.groupBox2.Controls.Add(this.cmdDodavanjeOcene);
            this.groupBox2.Controls.Add(this.cmdPrikazivanjeOcene);
            this.groupBox2.Location = new System.Drawing.Point(12, 192);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(401, 133);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ocena";
            // 
            // cmdAzuriranjeOcene
            // 
            this.cmdAzuriranjeOcene.Location = new System.Drawing.Point(5, 105);
            this.cmdAzuriranjeOcene.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdAzuriranjeOcene.Name = "cmdAzuriranjeOcene";
            this.cmdAzuriranjeOcene.Size = new System.Drawing.Size(228, 23);
            this.cmdAzuriranjeOcene.TabIndex = 5;
            this.cmdAzuriranjeOcene.Text = "Azuriranje ocene";
            this.cmdAzuriranjeOcene.UseVisualStyleBackColor = true;
            this.cmdAzuriranjeOcene.Click += new System.EventHandler(this.cmdAzuriranjeOcene_Click);
            // 
            // cmdBrisanjeOcene
            // 
            this.cmdBrisanjeOcene.Location = new System.Drawing.Point(8, 76);
            this.cmdBrisanjeOcene.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdBrisanjeOcene.Name = "cmdBrisanjeOcene";
            this.cmdBrisanjeOcene.Size = new System.Drawing.Size(228, 23);
            this.cmdBrisanjeOcene.TabIndex = 4;
            this.cmdBrisanjeOcene.Text = "Brisanje ocene";
            this.cmdBrisanjeOcene.UseVisualStyleBackColor = true;
            this.cmdBrisanjeOcene.Click += new System.EventHandler(this.cmdBrisanjeOcene_Click);
            // 
            // cmdDodavanjeOcene
            // 
            this.cmdDodavanjeOcene.Location = new System.Drawing.Point(5, 48);
            this.cmdDodavanjeOcene.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdDodavanjeOcene.Name = "cmdDodavanjeOcene";
            this.cmdDodavanjeOcene.Size = new System.Drawing.Size(228, 23);
            this.cmdDodavanjeOcene.TabIndex = 3;
            this.cmdDodavanjeOcene.Text = "Dodavanje ocene";
            this.cmdDodavanjeOcene.UseVisualStyleBackColor = true;
            this.cmdDodavanjeOcene.Click += new System.EventHandler(this.cmdDodavanjeOcene_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cmdAzuriranjeSmera);
            this.groupBox3.Controls.Add(this.cmdBrisanjeSmera);
            this.groupBox3.Controls.Add(this.cmdPrikazivanjeSmera);
            this.groupBox3.Controls.Add(this.cmdDodavanjeSmera);
            this.groupBox3.Controls.Add(this.cmdDodavanjeUcenikaNaSmer);
            this.groupBox3.Location = new System.Drawing.Point(675, 12);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(484, 126);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Smer";
            // 
            // cmdAzuriranjeSmera
            // 
            this.cmdAzuriranjeSmera.Location = new System.Drawing.Point(5, 102);
            this.cmdAzuriranjeSmera.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdAzuriranjeSmera.Name = "cmdAzuriranjeSmera";
            this.cmdAzuriranjeSmera.Size = new System.Drawing.Size(228, 23);
            this.cmdAzuriranjeSmera.TabIndex = 11;
            this.cmdAzuriranjeSmera.Text = "Azuriranje smera";
            this.cmdAzuriranjeSmera.UseVisualStyleBackColor = true;
            this.cmdAzuriranjeSmera.Click += new System.EventHandler(this.cmdAzuriranjeSmera_Click);
            // 
            // cmdBrisanjeSmera
            // 
            this.cmdBrisanjeSmera.Location = new System.Drawing.Point(5, 76);
            this.cmdBrisanjeSmera.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdBrisanjeSmera.Name = "cmdBrisanjeSmera";
            this.cmdBrisanjeSmera.Size = new System.Drawing.Size(228, 23);
            this.cmdBrisanjeSmera.TabIndex = 10;
            this.cmdBrisanjeSmera.Text = "Brisanje smera";
            this.cmdBrisanjeSmera.UseVisualStyleBackColor = true;
            this.cmdBrisanjeSmera.Click += new System.EventHandler(this.cmdBrisanjeSmera_Click);
            // 
            // cmdPrikazivanjeSmera
            // 
            this.cmdPrikazivanjeSmera.Location = new System.Drawing.Point(5, 20);
            this.cmdPrikazivanjeSmera.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdPrikazivanjeSmera.Name = "cmdPrikazivanjeSmera";
            this.cmdPrikazivanjeSmera.Size = new System.Drawing.Size(228, 23);
            this.cmdPrikazivanjeSmera.TabIndex = 9;
            this.cmdPrikazivanjeSmera.Text = "Prikazivanje smera";
            this.cmdPrikazivanjeSmera.UseVisualStyleBackColor = true;
            this.cmdPrikazivanjeSmera.Click += new System.EventHandler(this.cmdPrikazivanjeSmera_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cmdDodavanjeOcenePredmetu);
            this.groupBox4.Controls.Add(this.cmdBrisanjePredmeta);
            this.groupBox4.Controls.Add(this.cmdDodavanjePredmeta);
            this.groupBox4.Controls.Add(this.cmdPrikazivanjePredmeta);
            this.groupBox4.Controls.Add(this.Godine);
            this.groupBox4.Location = new System.Drawing.Point(683, 204);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Size = new System.Drawing.Size(476, 135);
            this.groupBox4.TabIndex = 19;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Predmet";
            // 
            // cmdDodavanjeOcenePredmetu
            // 
            this.cmdDodavanjeOcenePredmetu.Location = new System.Drawing.Point(257, 57);
            this.cmdDodavanjeOcenePredmetu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdDodavanjeOcenePredmetu.Name = "cmdDodavanjeOcenePredmetu";
            this.cmdDodavanjeOcenePredmetu.Size = new System.Drawing.Size(213, 25);
            this.cmdDodavanjeOcenePredmetu.TabIndex = 10;
            this.cmdDodavanjeOcenePredmetu.Text = "Dodavanje ocene predmetu";
            this.cmdDodavanjeOcenePredmetu.UseVisualStyleBackColor = true;
            this.cmdDodavanjeOcenePredmetu.Click += new System.EventHandler(this.cmdDodavanjeOcenePredmetu_Click);
            // 
            // cmdBrisanjePredmeta
            // 
            this.cmdBrisanjePredmeta.Location = new System.Drawing.Point(5, 84);
            this.cmdBrisanjePredmeta.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdBrisanjePredmeta.Name = "cmdBrisanjePredmeta";
            this.cmdBrisanjePredmeta.Size = new System.Drawing.Size(231, 23);
            this.cmdBrisanjePredmeta.TabIndex = 17;
            this.cmdBrisanjePredmeta.Text = "Brisanje predmeta";
            this.cmdBrisanjePredmeta.UseVisualStyleBackColor = true;
            this.cmdBrisanjePredmeta.Click += new System.EventHandler(this.cmdBrisanjePredmeta_Click);
            // 
            // cmdDodavanjePredmeta
            // 
            this.cmdDodavanjePredmeta.Location = new System.Drawing.Point(5, 58);
            this.cmdDodavanjePredmeta.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdDodavanjePredmeta.Name = "cmdDodavanjePredmeta";
            this.cmdDodavanjePredmeta.Size = new System.Drawing.Size(231, 23);
            this.cmdDodavanjePredmeta.TabIndex = 16;
            this.cmdDodavanjePredmeta.Text = "Dodavanje predmeta";
            this.cmdDodavanjePredmeta.UseVisualStyleBackColor = true;
            this.cmdDodavanjePredmeta.Click += new System.EventHandler(this.cmdDodavanjePredmeta_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cmdBrisanjeZaposlenog);
            this.groupBox5.Controls.Add(this.cmdDodavanjeNastavnogBN);
            this.groupBox5.Controls.Add(this.cmdDodavanjeNenastavnog);
            this.groupBox5.Controls.Add(this.cmdVisevrednosniAdresa);
            this.groupBox5.Controls.Add(this.cmdVisevrednosniSkole);
            this.groupBox5.Controls.Add(this.cmdDodavanjeNastavnogPN);
            this.groupBox5.Controls.Add(this.cmdPrikaziZaposlenog);
            this.groupBox5.Location = new System.Drawing.Point(675, 382);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox5.Size = new System.Drawing.Size(484, 140);
            this.groupBox5.TabIndex = 20;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Zaposleni";
            // 
            // cmdDodavanjeNenastavnog
            // 
            this.cmdDodavanjeNenastavnog.Location = new System.Drawing.Point(13, 20);
            this.cmdDodavanjeNenastavnog.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdDodavanjeNenastavnog.Name = "cmdDodavanjeNenastavnog";
            this.cmdDodavanjeNenastavnog.Size = new System.Drawing.Size(231, 23);
            this.cmdDodavanjeNenastavnog.TabIndex = 24;
            this.cmdDodavanjeNenastavnog.Text = "Dodavanje nenastavnog";
            this.cmdDodavanjeNenastavnog.UseVisualStyleBackColor = true;
            this.cmdDodavanjeNenastavnog.Click += new System.EventHandler(this.cmdDodavanjeNenastavnog_Click);
            // 
            // cmdVisevrednosniAdresa
            // 
            this.cmdVisevrednosniAdresa.Location = new System.Drawing.Point(13, 101);
            this.cmdVisevrednosniAdresa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdVisevrednosniAdresa.Name = "cmdVisevrednosniAdresa";
            this.cmdVisevrednosniAdresa.Size = new System.Drawing.Size(231, 30);
            this.cmdVisevrednosniAdresa.TabIndex = 23;
            this.cmdVisevrednosniAdresa.Text = "Visevrednosni adresa";
            this.cmdVisevrednosniAdresa.UseVisualStyleBackColor = true;
            this.cmdVisevrednosniAdresa.Click += new System.EventHandler(this.cmdVisevrednosniAdresa_Click);
            // 
            // cmdVisevrednosniSkole
            // 
            this.cmdVisevrednosniSkole.Location = new System.Drawing.Point(13, 74);
            this.cmdVisevrednosniSkole.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdVisevrednosniSkole.Name = "cmdVisevrednosniSkole";
            this.cmdVisevrednosniSkole.Size = new System.Drawing.Size(231, 23);
            this.cmdVisevrednosniSkole.TabIndex = 23;
            this.cmdVisevrednosniSkole.Text = "Visevrednosni skole";
            this.cmdVisevrednosniSkole.UseVisualStyleBackColor = true;
            this.cmdVisevrednosniSkole.Click += new System.EventHandler(this.cmdVisevrednosniSkole_Click);
            // 
            // cmdDodavanjeNastavnogPN
            // 
            this.cmdDodavanjeNastavnogPN.Location = new System.Drawing.Point(253, 20);
            this.cmdDodavanjeNastavnogPN.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdDodavanjeNastavnogPN.Name = "cmdDodavanjeNastavnogPN";
            this.cmdDodavanjeNastavnogPN.Size = new System.Drawing.Size(231, 23);
            this.cmdDodavanjeNastavnogPN.TabIndex = 11;
            this.cmdDodavanjeNastavnogPN.Text = "Dodavanje nastavnog PN";
            this.cmdDodavanjeNastavnogPN.UseVisualStyleBackColor = true;
            this.cmdDodavanjeNastavnogPN.Click += new System.EventHandler(this.cmdDodavanjeNastavnogPN_Click_1);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.cmdAzuriranjeRoditelja);
            this.groupBox6.Controls.Add(this.cmdBrisanjeRoditelja);
            this.groupBox6.Controls.Add(this.cmdPrikazivanjeRoditelja);
            this.groupBox6.Controls.Add(this.cmdDodavanjeRoditelja);
            this.groupBox6.Location = new System.Drawing.Point(12, 369);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox6.Size = new System.Drawing.Size(401, 129);
            this.groupBox6.TabIndex = 21;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Roditelj";
            // 
            // cmdAzuriranjeRoditelja
            // 
            this.cmdAzuriranjeRoditelja.Location = new System.Drawing.Point(0, 101);
            this.cmdAzuriranjeRoditelja.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdAzuriranjeRoditelja.Name = "cmdAzuriranjeRoditelja";
            this.cmdAzuriranjeRoditelja.Size = new System.Drawing.Size(231, 23);
            this.cmdAzuriranjeRoditelja.TabIndex = 13;
            this.cmdAzuriranjeRoditelja.Text = "Azuriranje roditelja";
            this.cmdAzuriranjeRoditelja.UseVisualStyleBackColor = true;
            this.cmdAzuriranjeRoditelja.Click += new System.EventHandler(this.cmdAzuriranjeRoditelja_Click);
            // 
            // cmdBrisanjeRoditelja
            // 
            this.cmdBrisanjeRoditelja.Location = new System.Drawing.Point(0, 78);
            this.cmdBrisanjeRoditelja.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdBrisanjeRoditelja.Name = "cmdBrisanjeRoditelja";
            this.cmdBrisanjeRoditelja.Size = new System.Drawing.Size(231, 23);
            this.cmdBrisanjeRoditelja.TabIndex = 12;
            this.cmdBrisanjeRoditelja.Text = "Brisanje rodtielja";
            this.cmdBrisanjeRoditelja.UseVisualStyleBackColor = true;
            this.cmdBrisanjeRoditelja.Click += new System.EventHandler(this.cmdBrisanjeRoditelja_Click);
            // 
            // cmdPrikazivanjeRoditelja
            // 
            this.cmdPrikazivanjeRoditelja.Location = new System.Drawing.Point(0, 21);
            this.cmdPrikazivanjeRoditelja.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdPrikazivanjeRoditelja.Name = "cmdPrikazivanjeRoditelja";
            this.cmdPrikazivanjeRoditelja.Size = new System.Drawing.Size(231, 23);
            this.cmdPrikazivanjeRoditelja.TabIndex = 11;
            this.cmdPrikazivanjeRoditelja.Text = "Prikazivanje roditelja";
            this.cmdPrikazivanjeRoditelja.UseVisualStyleBackColor = true;
            this.cmdPrikazivanjeRoditelja.Click += new System.EventHandler(this.cmdPrikazivanjeRoditelja_Click);
            // 
            // cmdOneToManyUcenikSmer
            // 
            this.cmdOneToManyUcenikSmer.Location = new System.Drawing.Point(428, 78);
            this.cmdOneToManyUcenikSmer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdOneToManyUcenikSmer.Name = "cmdOneToManyUcenikSmer";
            this.cmdOneToManyUcenikSmer.Size = new System.Drawing.Size(228, 23);
            this.cmdOneToManyUcenikSmer.TabIndex = 22;
            this.cmdOneToManyUcenikSmer.Text = "One-to-Many Ucenik Smer";
            this.cmdOneToManyUcenikSmer.UseVisualStyleBackColor = true;
            this.cmdOneToManyUcenikSmer.Click += new System.EventHandler(this.cmdOneToManyUcenikSmer_Click);
            // 
            // cmdManyToOnePredmetOcene
            // 
            this.cmdManyToOnePredmetOcene.Location = new System.Drawing.Point(437, 262);
            this.cmdManyToOnePredmetOcene.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdManyToOnePredmetOcene.Name = "cmdManyToOnePredmetOcene";
            this.cmdManyToOnePredmetOcene.Size = new System.Drawing.Size(228, 23);
            this.cmdManyToOnePredmetOcene.TabIndex = 23;
            this.cmdManyToOnePredmetOcene.Text = "Many-to-One Predmet Ocene";
            this.cmdManyToOnePredmetOcene.UseVisualStyleBackColor = true;
            this.cmdManyToOnePredmetOcene.Click += new System.EventHandler(this.cmdManyToOnePredmetOcene_Click);
            // 
            // cmdAzuriranjePredmeta
            // 
            this.cmdAzuriranjePredmeta.Location = new System.Drawing.Point(688, 316);
            this.cmdAzuriranjePredmeta.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdAzuriranjePredmeta.Name = "cmdAzuriranjePredmeta";
            this.cmdAzuriranjePredmeta.Size = new System.Drawing.Size(231, 23);
            this.cmdAzuriranjePredmeta.TabIndex = 18;
            this.cmdAzuriranjePredmeta.Text = "Azuriranje predmeta";
            this.cmdAzuriranjePredmeta.UseVisualStyleBackColor = true;
            this.cmdAzuriranjePredmeta.Click += new System.EventHandler(this.cmdAzuriranjePredmeta_Click);
            // 
            // cmdDodavanjeNastavnogBN
            // 
            this.cmdDodavanjeNastavnogBN.Location = new System.Drawing.Point(253, 47);
            this.cmdDodavanjeNastavnogBN.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdDodavanjeNastavnogBN.Name = "cmdDodavanjeNastavnogBN";
            this.cmdDodavanjeNastavnogBN.Size = new System.Drawing.Size(231, 23);
            this.cmdDodavanjeNastavnogBN.TabIndex = 25;
            this.cmdDodavanjeNastavnogBN.Text = "Dodavanje nastavnog BN";
            this.cmdDodavanjeNastavnogBN.UseVisualStyleBackColor = true;
            this.cmdDodavanjeNastavnogBN.Click += new System.EventHandler(this.cmdDodavanjeNastavnogBN_Click);
            // 
            // cmdBrisanjeZaposlenog
            // 
            this.cmdBrisanjeZaposlenog.Location = new System.Drawing.Point(256, 74);
            this.cmdBrisanjeZaposlenog.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdBrisanjeZaposlenog.Name = "cmdBrisanjeZaposlenog";
            this.cmdBrisanjeZaposlenog.Size = new System.Drawing.Size(228, 23);
            this.cmdBrisanjeZaposlenog.TabIndex = 26;
            this.cmdBrisanjeZaposlenog.Text = "Brisanje zaposlenog";
            this.cmdBrisanjeZaposlenog.UseVisualStyleBackColor = true;
            this.cmdBrisanjeZaposlenog.Click += new System.EventHandler(this.cmdBrisanjeZaposlenog_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1173, 533);
            this.Controls.Add(this.cmdAzuriranjePredmeta);
            this.Controls.Add(this.cmdManyToOnePredmetOcene);
            this.Controls.Add(this.cmdOneToManyUcenikSmer);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmdManyToManyNastavnikPredmet);
            this.Controls.Add(this.cmd_ManyToManyPredmetSmer);
            this.Controls.Add(this.cmdOneToManyPredmetOcene);
            this.Controls.Add(this.cmdManyToOneUcenikSmer);
            this.Controls.Add(this.cmdManyToOneUcenikOcena);
            this.Controls.Add(this.cmdOneToManyUcenikOcena);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdPrikazivanjeUcenika;
        private System.Windows.Forms.Button cmdDodavanjeUcenika;
        private System.Windows.Forms.Button cmdPrikazivanjeOcene;
        private System.Windows.Forms.Button cmdOneToManyUcenikOcena;
        private System.Windows.Forms.Button cmdManyToOneUcenikOcena;
        private System.Windows.Forms.Button cmdDodavanjeSmera;
        private System.Windows.Forms.Button cmdPrikazivanjePredmeta;
        private System.Windows.Forms.Button cmdManyToOneUcenikSmer;
        private System.Windows.Forms.Button cmdDodavanjeUcenikaNaSmer;
        private System.Windows.Forms.Button cmdOneToManyPredmetOcene;
        private System.Windows.Forms.Button cmdDodavanjeRoditelja;
        private System.Windows.Forms.Button cmd_ManyToManyPredmetSmer;
        private System.Windows.Forms.Button cmdPrikaziZaposlenog;
        private System.Windows.Forms.Button cmdManyToManyNastavnikPredmet;
        private System.Windows.Forms.Button Godine;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button cmdBrisanjeUcenika;
        private System.Windows.Forms.Button cmdAzuriranjeUcenika;
        private System.Windows.Forms.Button cmdOneToManyUcenikSmer;
        private System.Windows.Forms.Button cmdVisevrednosniSkole;
        private System.Windows.Forms.Button cmdVisevrednosniAdresa;
        private System.Windows.Forms.Button cmdDodavanjeOcene;
        private System.Windows.Forms.Button cmdBrisanjeOcene;
        private System.Windows.Forms.Button cmdAzuriranjeOcene;
        private System.Windows.Forms.Button cmdManyToOnePredmetOcene;
        private System.Windows.Forms.Button cmdPrikazivanjeSmera;
        private System.Windows.Forms.Button cmdBrisanjeSmera;
        private System.Windows.Forms.Button cmdAzuriranjeSmera;
        private System.Windows.Forms.Button cmdDodavanjeOceneUceniku;
        private System.Windows.Forms.Button cmdBrisanjePredmeta;
        private System.Windows.Forms.Button cmdDodavanjePredmeta;
        private System.Windows.Forms.Button cmdAzuriranjePredmeta;
        private System.Windows.Forms.Button cmdDodavanjeOcenePredmetu;
        private System.Windows.Forms.Button cmdPrikazivanjeRoditelja;
        private System.Windows.Forms.Button cmdAzuriranjeRoditelja;
        private System.Windows.Forms.Button cmdBrisanjeRoditelja;
        private System.Windows.Forms.Button cmdDodavanjeNenastavnog;
        private System.Windows.Forms.Button cmdDodavanjeNastavnogPN;
        private System.Windows.Forms.Button cmdDodavanjeNastavnogBN;
        private System.Windows.Forms.Button cmdBrisanjeZaposlenog;
    }
}

