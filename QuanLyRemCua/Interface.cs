using QuanLyRemCua.ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyRemCua
{
    class Interface
    {
        public static void showAllCurtain()
        {
            Console.Clear();
            string title = "Danh sach man cua";
            var table = new ConsoleTable("Ten", "Ma", "Mau sac", "Loai", "Gia", "So Luong");
            Console.WriteLine(String.Format("{0," + ((80 / 2) + (title.Length / 2)) + "}", title));

            foreach (Curtain curtain in Database.curtains)
            {
                Dictionary<string, string> processDictionary = curtain.getData();
                table.AddRow(
                processDictionary["name"],
                processDictionary["code"],
                processDictionary["color"],
                processDictionary["type"],
                processDictionary["price"] + " VND",
                processDictionary["amount"]);
            }
            table.Write();
            Console.WriteLine();
            Console.Write("Bam phim bat ki de ve man hinh chinh.");
            Console.ReadKey();
        }
        public static void addCurtain()
        {
            Edit:
            try
            {
                Console.Write("Nhap vao ten man :  ");
                string name = Console.ReadLine();
                Console.Write("Nhap vao ma man :  ");
                string code = Console.ReadLine();
                Console.Write("Nhap vao mau sac cua man :  ");
                string color = Console.ReadLine();
                Console.Write("Nhap vao loai man :  ");
                string type = Console.ReadLine();
                Console.Write("Nhap vao gia man :  ");
                string price = Console.ReadLine();
                if (price != "")
                {
                    float tempPrice = float.Parse(price);
                    price = tempPrice.ToString();
                }
                else {
                    throw new InvalidCastException();
                }
                Console.Write("Nhap vao so luong man :  ");
                string amount = Console.ReadLine();
                if (amount != "")
                {
                    float tempAmount = float.Parse(amount);
                    amount = tempAmount.ToString();
                }
                else {
                    throw new InvalidCastException();
                }
                if (name == "" || code == "" || color == "" || type == "") {
                    throw new InvalidCastException();
                }
                Database.curtains.Add(new Curtain(name, code, color, type, float.Parse(price), int.Parse(amount)));
            }
            catch
            {
                Console.Write("Gia tri khong hop le.Bam phim bat ki de nhap lai hoac bam 0 de huy");
                ConsoleKey key = Console.ReadKey().Key;
                if (key == ConsoleKey.D0 || key == ConsoleKey.NumPad0) {
                    return;
                } 
                Console.Clear();
                goto Edit;
            }

        }
        public static void findCurtain()
        {
            Console.Clear();
            Console.Write("Nhap vao thong tin man can tim: ");
            string input = Console.ReadLine();
            Console.Clear();
            string title = "Danh sach ket qua tim kiem cho tu khoa ";
            var table = new ConsoleTable("Ten", "Ma", "Mau sac", "Loai", "Gia", "So Luong");
            Console.WriteLine(String.Format("{0," + ((80 / 2) + (title.Length / 2)) + "}\"{1}\"", title, input));
            foreach (Curtain curtain in Database.curtains)
            {
                if (curtain.isMe(input))
                {

                    Dictionary<string, string> processDictionary = curtain.getData();
                    table.AddRow(
                    processDictionary["name"],
                    processDictionary["code"],
                    processDictionary["color"],
                    processDictionary["type"],
                    processDictionary["price"] + " VND",
                    processDictionary["amount"]);
                }
            }
            table.Write();
            Console.WriteLine();
            Console.Write("Bam phim bat ki de ve man hinh chinh.");
            Console.ReadKey();
        }

        public static void modifyCurtain()
        {
            Console.Clear();
            Dictionary<string, string> processDictionary = null;
            int index = -1;
            Console.Write("Nhap vao ma so man can sua: ");
            string input = Console.ReadLine();
            foreach (Curtain curtain in Database.curtains)
            {
                Dictionary<string, string> tempDic = curtain.getData();
                if (tempDic["code"] == input)
                {
                    index = Database.curtains.IndexOf(curtain);
                    processDictionary = tempDic;
                    break;
                }
            }
            if (processDictionary != null)
            {
                ConsoleTable info = new ConsoleTable(new ConsoleTableOptions
                {
                    EnableCount = false,
                    Columns = new[] { "Ten", "Ma", "Mau sac", "Loai", "Gia", "So Luong" }
                });
                info.AddRow(
                   processDictionary["name"],
                   processDictionary["code"],
                   processDictionary["color"],
                   processDictionary["type"],
                   processDictionary["price"] + " VND",
                   processDictionary["amount"]);
                Edit:
                Console.Clear();
                info.Write();

                try
                {
                    Console.Write("Nhap vao ten man [{0}]:  ", processDictionary["name"]);
                    string name = Console.ReadLine();
                    Console.Write("Nhap vao ma man [{0}]:  ", processDictionary["code"]);
                    string code = Console.ReadLine();
                    Console.Write("Nhap vao mau sac cua man [{0}]:  ", processDictionary["color"]);
                    string color = Console.ReadLine();
                    Console.Write("Nhap vao loai man [{0}]:  ", processDictionary["type"]);
                    string type = Console.ReadLine();
                    Console.Write("Nhap vao gia man [{0}]:  ", processDictionary["price"]);
                    string price = Console.ReadLine();
                    if (price != "")
                    {
                        float tempPrice = float.Parse(price);
                        price = tempPrice.ToString();
                    }
                    Console.Write("Nhap vao so luong man [{0}]:  ", processDictionary["amount"]);
                    string amount = Console.ReadLine();
                    if (amount != "")
                    {
                        float tempAmount = float.Parse(amount);
                        amount = tempAmount.ToString();
                    }
                    string[] modificationInfo = { name, code, color, type, price, amount };
                    Database.curtains[index].changeData(modificationInfo);
                }
                catch
                {
                    Console.Write("Gia tri khong hop le.Bam phim bat ki de nhap lai.");
                    Console.ReadKey();
                    Console.Clear();
                    goto Edit;
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Khong tim thay man cua co ma so: {0}. Bam phim bat ki de tro ve menu.", input);
                Console.ReadKey();
            }
        }
        public static void deleteCurtain()
        {
            Console.Clear();
            Dictionary<string, string> processDictionary = null;
            int index = -1;
            Console.Write("Nhap vao ma so man can xoa: ");
            string input = Console.ReadLine();
            foreach (Curtain curtain in Database.curtains)
            {
                Dictionary<string, string> tempDic = curtain.getData();
                if (tempDic["code"] == input)
                {
                    index = Database.curtains.IndexOf(curtain);
                    processDictionary = tempDic;
                    break;
                }
            }
            if (processDictionary != null)
            {
                ConsoleTable info = new ConsoleTable(new ConsoleTableOptions
                {
                    EnableCount = false,
                    Columns = new[] { "Ten", "Ma", "Mau sac", "Loai", "Gia", "So Luong" }
                });
                info.AddRow(
                   processDictionary["name"],
                   processDictionary["code"],
                   processDictionary["color"],
                   processDictionary["type"],
                   processDictionary["price"] + " VND",
                   processDictionary["amount"]);
                Confirmation:
                Console.Clear();
                info.Write();
                Console.Write("Ban co chac chan muon xoa man (y/n): ");
                string answer = Console.ReadLine();
                if (answer != "y" && answer != "n")
                {
                    Console.Clear();
                    Console.WriteLine("Khong hop le. Bam phim bat ki de nhap lai.");
                    Console.ReadKey();
                    Console.Clear();
                    goto Confirmation;
                }
                else
                {
                    if (answer == "y")
                    {
                        Database.curtains.RemoveAt(index);
                        Console.Clear();
                        Console.WriteLine("Xoa man cua thanh cong. Bam phim bat ki de tro ve menu.");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Huy xoa man cua thanh cong. Bam phim bat ki de tro ve menu.");
                        Console.ReadKey();
                    }
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Khong tim thay man cua co ma so: {0}. Bam phim bat ki de tro ve menu.", input);
                Console.ReadKey();
            }
        }
    }
}
