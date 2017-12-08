using SimpleCMenu.Menu;
using System;

namespace QuanLyRemCua
{
    class Program
    {
        static void exit() {
            Environment.Exit(69);
        }
        static void Main(string[] args) {
            Database.UpdateDataset();
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
            menu.addMenuItem(1, "Them man cua", Interface.addCurtain);
            menu.addMenuItem(2, "Xem tat ca man cua", Interface.showAllCurtain);
            menu.addMenuItem(3, "Tim kiem man cua", Interface.findCurtain);
            menu.addMenuItem(4, "Sua thong tin man cua", Interface.modifyCurtain);
            menu.addMenuItem(5, "Xoa man cua", Interface.deleteCurtain);
            menu.addMenuItem(0, "Thoat",Program.exit);
            menu.showMenu();
            Console.ReadKey();
            Database.UpdateDatabase();
        }
    }
}
