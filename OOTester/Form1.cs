using Newtonsoft.Json;
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

namespace OOTester
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Dungeon dungeon = new Dungeon("Pippa's Dungeon");
            //Room room = new Room(dungeon, new Tuple<int, int>(5, 0), hasWesternBoundary: true);
            //Player player = new Player(room, "Ciliza");
            //Monster monster = new Monster(room, "Gollum");
            //Item potion = new Potion(player, "Healing Potion", "Restore 50 HP");

            //Room currentRoom = dungeon.FindPlayer(player);
            //listBox1.DataSource = currentRoom.ListContents();
        }

        private class Dungeon
        {
            public Guid ID { get; set; }
            public string Name { get; set; }
            //public Dictionary<Tuple<int, int>, Room> Rooms { get; set; } = new Dictionary<Tuple<int, int>, Room>();
            public List<Room> Rooms { get; set; }

            public Dungeon(/*string name, List<Room> rooms*/)
            {
                ID = Guid.NewGuid();
                //Name = name;
                //Rooms = rooms;
            }

            //public Room FindPlayer(Player player)
            //{
            //    //var players;
            //    foreach (var r in Rooms)
            //        if (r.Value.Beings != null)
            //        {
            //            for (var i = 0; i <= r.Value.Beings.Count - 1; i++)
            //            {
            //                if (r.Value.Beings[i].ID == player.ID)
            //                    return r.Value;
            //            }
            //        }

            //    return null;
            //}
        }

        private class Room
        {
            public Guid ID { get; set; }
            private Tuple<int, int> Coordinates { get; }
            private bool HasNorthernWall { get; }
            private bool HasEasternWall { get; }
            private bool HasSouthernWall { get; }
            private bool HasWesternWall { get; }
            
            //public List<Being> Beings { get; set; } = new List<Being>();


            public Room(/*Dungeon dungeon,*/ Tuple<int, int> coordinates, bool hasNorthernWall, bool hasEasternWall, bool hasSouthernWall, bool hasWesternWall)
            {
                ID = Guid.NewGuid();
                Coordinates = coordinates;
                HasNorthernWall = hasNorthernWall;
                HasEasternWall = hasEasternWall;
                HasSouthernWall = hasSouthernWall;
                HasWesternWall = hasWesternWall;


                //dungeon.Rooms.Add(Coordinates, this);
            }

            //public List<string> ListContents()
            //{
            //    List<string> contents = new List<string>();

            //    foreach (Being b in Beings)
            //        contents.Add(b.Name);

            //    return contents;
            //}
        }

        private abstract class Being
        {
            public Guid ID { get; set; }
            public string Name { get; set; }
            public int CurrentHP { get; set; }
            public int MaximumHP { get; set; }
            public int Level { get; set; } = 1;
            public List<Item> Items { get; set; } = new List<Item>();
            //public Room CurrentRoom { get; set; }

            public Being()
            {

            }

            public Being(Room currentRoom, string name)
            {
                ID = Guid.NewGuid();
                Name = name;
                MaximumHP = 100;
                CurrentHP = MaximumHP;
                //CurrentRoom = currentRoom;

                //currentRoom.Beings.Add(this);
            }
        }

        private class Player : Being
        {
            public int Experience { get; set; } = 42;

            public Player(Room currentRoom, string name) : base(currentRoom, name)
            {

            }

            //public List<string> LookAroundRoom(Room currentRoom)
            //{
            //    List<string> targets = new List<string>();

            //    foreach (Being b in currentRoom.Beings)
            //        targets.Add(b.Name);

            //    return targets;
            //}
        }

        private class Monster : Being
        {
            public int EvilLevel { get; set; } = 3;

            public Monster(Room currentRoom, string name) : base(currentRoom, name)
            {

            }
        }

        private abstract class Item
        {
            public Guid ID { get; set; }
            public string Name { get; set; }
            public int Quantity { get; set; }

            public Item()
            {

            }

            public Item(Being being, string name)
            {
                ID = Guid.NewGuid();
                Name = name;
                Quantity = 12;

                being.Items.Add(this);
            }
        }

        private class Potion : Item
        {
            public string Effect { get; set; }

            public Potion(Being being, string name, string effect) : base(being, name)
            {
                Effect = effect;
            }
        }

        public void LoadJson()
        {
            using (StreamReader r = new StreamReader(@"C:\Users\james\Desktop\Harry Potter's Revenge.json"))
            {
                string json = r.ReadToEnd();
                Dungeon dungeons = JsonConvert.DeserializeObject<Dungeon>(json);

                int i = 0;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadJson();
        }
    }
}