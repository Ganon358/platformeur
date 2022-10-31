using System;

namespace platformeur
{
    public partial class Form1 : Form
    {
        bool droite, gauche;
        bool jump;
        int saut =30;
        int timesaut = 0;
        int vitesse=10;
        int vitessem = 3;
        int vitesseb = 3;
        int vitesser = 3;
        int gravitation = 15 ;
        int piece = 0;
        int start = 0;
        int message = 1;
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

        private void begin()
        {
            foreach (Control m in this.Controls)
            {
                if (m is PictureBox && (string)m.Tag == "start")
                {
                    if (player.Bounds.IntersectsWith(m.Bounds))
                    {
                        this.Controls.Remove(pictureBox22);
                        start += 1;
                    }
                }
            }
        }

        private void win()
        {
            foreach (Control z in this.Controls)
            {
                foreach (Control m in this.Controls)
                {
                    if (z is PictureBox && (string)z.Tag == "bouton")
                    {
                        if (player.Bounds.IntersectsWith(z.Bounds))
                        {
                            this.Controls.Remove(pictureBox21);
                            this.Controls.Remove(pictureBox17);
                            this.Controls.Remove(pictureBox19);
                            if (m is PictureBox && (string)m.Tag == "boss")
                            {
                                m.Top += 100;
                            }
                        }
                    }
                }
            }
        }

        private void gravity()
        {
            foreach (Control m in this.Controls)
            {
                if (m is PictureBox && (string)m.Tag == "monstre")
                {
                    m.Top += gravitation;
                    m.BringToFront();
                    m.Left += vitessem;
                }
            }
        }

        private void BOSS()
        {
            foreach (Control m in this.Controls)
            {
                if (m is PictureBox && (string)m.Tag == "boss")
                {
                    m.Top += gravitation;
                    m.BringToFront();
                   if (start==1)
                    {
                        m.Left += vitesseb;
                        if (m.Left < 254 || m.Left > 683)
                        {
                            vitesseb = -vitesseb;
                        }
                    }
                }
            }
        }

        private void gravityr()
        {
            foreach (Control m in this.Controls)
            {
                if (m is PictureBox && (string)m.Tag == "rouge")
                {
                    m.Top += gravitation;
                    m.BringToFront();
                    m.Left += vitesser;
                    if (m.Left < 773 || m.Left > 938)
                    {
                        vitesser = -vitesser;
                    }
                }
            }
        }

        private void plateform()
        {
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "supportmoove")
                {

                    x.Left += vitessem;
                    if (x.Left < 554 ||x.Left > 1100)
                    {
                        vitessem = -vitessem;
                    }
                    if (player.Bounds.IntersectsWith(x.Bounds))
                    {
                        player.Top -= gravitation;
                        timesaut = 10;
                        if (x.Left < 554 || x.Left > 1100)
                        {
                            player.Left -= vitessem;
                        }
                        else
                        {
                            player.Left += vitessem;
                        }
                    }
                }
            }
        }

        private void gameover()
        {
            if (message == 1)
            {
                moove.Stop();
                MessageBox.Show("Game Over");
                message++;
                return;
            }
           
  
            
        }

        private void youwin()
        {
            if (message == 1)
            {
                moove.Stop();
                MessageBox.Show("You Win");
                message++;
                return;
            }



        }

        private void mooveevent(object sender, EventArgs e)
        {
            saut = 30;
            player.Top += gravitation;
            gravity();
            gravityr();
            BOSS();
            plateform();
            begin();
            win();
           
           
          
            if (gauche == true && player.Left > 0)
            {
                player.Left -= vitesse;
            }
            if (droite == true && player.Left < 2000)
            {
                player.Left += vitesse;
            }
            if (jump == true && player.Top > 0 && timesaut > 0)
            {
                player.Top -= saut;
                timesaut -= 1;
                saut -= 2;
                

            }
            if (player.Top >= 538)
            {
                this.Controls.Remove(player);
                gameover();
            }
            foreach (Control x in this.Controls)
            {
                foreach (Control m in this.Controls)
                {
                    if (m is PictureBox && (string)m.Tag == "monstre")
                    {

                        if (player.Bounds.IntersectsWith(m.Bounds))
                        {
                            this.Controls.Remove(player);
                            gameover();
                           

                        }
                        if (x is PictureBox && (string)x.Tag == "support")
                        {
                            if (m.Bounds.IntersectsWith(x.Bounds))
                            {
                                m.Top -= gravitation;
                            }
                        }
                    }
                    if (x is PictureBox && (string)x.Tag == "winner")
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds))
                        {
                            youwin();
                        }
                    }

                    if (x is PictureBox && (string)x.Tag == "support")
                    {

                        if (player.Bounds.IntersectsWith(x.Bounds))
                        {
                            player.Top -= gravitation;
                            timesaut = 10;
                        }

                    }

                   
                    if (x is PictureBox && (string)x.Tag == "piece")
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds))
                        {
                            this.Controls.Remove(x);
                            piece += 1;
                            this.label1.Text = piece.ToString();
                            break;
                        }

                    }
                    if (m is PictureBox && (string)m.Tag == "rouge")
                    {

                        if (player.Bounds.IntersectsWith(m.Bounds))
                        {
                            this.Controls.Remove(player);
                            gameover();

                        }
                        if (x is PictureBox && (string)x.Tag == "support")
                        {
                            if (m.Bounds.IntersectsWith(x.Bounds))
                            {
                                m.Top -= gravitation;
                            }
                        }
                    }

                    if (m is PictureBox && (string)m.Tag == "boss")
                    {

                        if (player.Bounds.IntersectsWith(m.Bounds))
                        {
                            this.Controls.Remove(player);
                            gameover();
                            
                           

                        }
                        if (x is PictureBox && (string)x.Tag == "support")
                        {
                            if (m.Bounds.IntersectsWith(x.Bounds))
                            {
                                m.Top -= gravitation;
                            }
                        }
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


        private void label1_Click(object sender, EventArgs e)
        {
            
        
        }

        private void pieceAdd(object sender, ControlEventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
         
        }

        private void monstre_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox22_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox21_Click(object sender, EventArgs e)
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