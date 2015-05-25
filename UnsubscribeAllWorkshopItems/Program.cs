using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Steamworks;

namespace UnsubscribeAllWorkshopItems
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                DoWork();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            Console.ReadLine();
        }

        private static void DoWork()
        {
            Console.WriteLine("This program will attempt to unsubscribe from all workshop items for the game id specified in the txt file included.");
            Console.WriteLine("You will be given a confirmation message before everything is unsubscribed, Once confirming that there is no returning.");
            Steamworks.SteamAPI.Init();
            var num = SteamUGC.GetNumSubscribedItems();

            PublishedFileId_t[] files = new PublishedFileId_t[num];
            
            Steamworks.SteamUGC.GetSubscribedItems(files, num);
            Console.Write("Are you sure you want to unsubscribe {0} items? (y/n): ", num);
            if (Console.ReadLine() != "y")
            {
                Console.WriteLine("Operation Cancelled");
                return;
            }
            foreach (var file in files)
            {
                Console.WriteLine("Unsubscribing: " + file.m_PublishedFileId);
                SteamUGC.UnsubscribeItem(file);
            }
            
            Console.WriteLine("Finished.");
        }
    }
}
