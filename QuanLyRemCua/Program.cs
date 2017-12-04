using SimpleCMenu.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyRemCua
{
    class Program
    {
        static void exit() {
            Environment.Exit(69);
        }
        static void Main(string[] args)
        {
            Curtain cur1 = new Curtain("Manh sao", "MS1", "Trang", "Manh Sao Ngang", 22000, 2);
            Curtain cur2 = new Curtain("Manh sao", "MS2", "Den", "Manh Sao Doc", 22000, 2);
            Curtain cur3 = new Curtain("Manh sao", "MS3", "Deo co mau", "Manh Sao 3D", 99000, 2);
            Database.curtains.Add(cur1);
            Database.curtains.Add(cur2);
            Database.curtains.Add(cur3);
            Console.Clear();
            ConsoleMenu menu = new ConsoleMenu();
            string headerText =       "  ____                      _                                                " +
                Environment.NewLine + " / __ \\                    | |                                               " +
                Environment.NewLine + "| |  | |_   _  __ _ _ __   | |_   _   _ __ ___ _ __ ___      ___ _   _  __ _ " +
                Environment.NewLine + "| |  | | | | |/ _` | '_ \\  | | | | |  | '__/ _ \\ '_ ` _ \\   / __| | | |/ _` |" +
                Environment.NewLine + "| |__| | |_| | (_| | | | | | | |_| |  | | |  __/ | | | | | | (__| |_| | (_| |" +
                Environment.NewLine + " \\___\\_\\__,_ |\\__,_|_| |_| |_|\\__, |  |_|  \\___|_| |_| |_|  \\___|\\__,_|\\__,_|" +
                Environment.NewLine + "                             __/ ,/                                           " +
                Environment.NewLine + "                            |___/                                     ";
            menu.Header = headerText;          
            menu.SubTitle = "\n-----------------------------------MENU---------------------------------------";
            menu.addMenuItem(1, "Xem tat ca man cua", Interface.showAllCurtain);
            menu.addMenuItem(2, "Tim kiem man cua", Interface.findCurtain);
            menu.addMenuItem(3, "Sua thong tin man cua", Interface.modifyCurtain);
            menu.addMenuItem(4, "Xoa man cua", Interface.deleteCurtain);
            menu.addMenuItem(0, "Thoat",Program.exit);
            menu.showMenu();
            Console.ReadKey();
        }
    }
}
