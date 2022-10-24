namespace platformeur
{
    public partial class Form1 : Form
    {
        bool droite, gauche;
        bool jump;
        int saut =30;
        int timesaut = 0;
        int vitesse=10;
        int gravitation = 15 ;
        int piece = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void support(object sender, EventArgs e) 
        { 
            
        }

        private void player_Click(object sender, EventArgs e)
        {
          
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click (object sender, EventArgs e)
        {

        }

        private void mooveevent(object sender, EventArgs e)
        {
            saut = 30;
            player.Top += gravitation;
            if (gauche == true && player.Left > 0)
            {
                player.Left -= vitesse;
            }
            if (droite == true && player.Left < 750)
            {
                player.Left += vitesse;
            }
            if (jump == true && player.Top > 0 && timesaut > 0)
            {
                player.Top -= saut;
                timesaut -= 1;
                saut -= 2;
            }
            foreach (Control x in this.Controls)
                foreach (Control y in this.Controls)
                {

                    {

                        if (x is PictureBox && (string)x.Tag == "support")

                        {
                            if (y is PictureBox && (string)y.Tag == "monstre")
                            {
                                y.Top += gravitation;
                                if (y.Bounds.IntersectsWith(x.Bounds))
                                {
                                    y.Top -= 15;
                                }
                            }
                            if (player.Bounds.IntersectsWith(x.Bounds))
                            {
                                player.Top -= 15;
                                timesaut = 10;


                            }
                        }
                        if (x is PictureBox && (string)x.Tag == "piece")

                        {
                            

                        }
                    }
                }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode== Keys.Left)
            {
                gauche=true;
            }
            if (e.KeyCode == Keys.Right)
            {
                droite = true;
            }
            if (e.KeyCode == Keys.Space)
            {
                jump = true; 
            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }


        private void compteurpiece_Tick(object sender, EventArgs e)
        {

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                gauche = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                droite = false;
            }
            if (e.KeyCode == Keys.Space)
            {
                jump = false;
                timesaut = 0;
            }
        }
    }
}