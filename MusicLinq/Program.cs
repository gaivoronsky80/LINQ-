using System;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Collections to work with
            List<Artist> Artists = MusicStore.GetData().AllArtists;
            List<Group> Groups = MusicStore.GetData().AllGroups;

            //========================================================
            //Solve all of the prompts below using various LINQ queries
            //========================================================

            //Display the name and age of the one artist from Mount Vernon.

            IEnumerable<Artist> justHometown = Artists.Where(artist => artist.Hometown == "Mount Vernon");
            foreach(Artist artist in justHometown)
            {
                Console.WriteLine(artist.RealName);
                Console.WriteLine(artist.ArtistName);
                Console.WriteLine(artist.Age);
            }

            //Display the youngest artist's info.

            Artist youngestAge = Artists.OrderBy(artist => artist.Age).FirstOrDefault();
                Console.WriteLine(youngestAge.RealName);
                Console.WriteLine(youngestAge.ArtistName);
                Console.WriteLine(youngestAge.Age);

            //Display all artists with 'William' somewhere in their real name.

            IEnumerable<Artist> justRealName = Artists.Where(artist => artist.RealName.Contains("William"));
            foreach(Artist artist in justRealName)
            {
                Console.WriteLine(artist.RealName);
            }

            //Display all groups with names less than 8 characters in length.

            IEnumerable<Group> lengthGroup = Groups.Where(group => group.GroupName.Length < 8);
            foreach(Group group in lengthGroup)
            {
                Console.WriteLine(group.GroupName);
            }

            //Display the 3 oldest artists from Atlanta.

            IEnumerable<Artist> oldestArtist = Artists.Where(artist => artist.Hometown == "Atlanta").OrderByDescending(artist => artist.Age).Take(3);
            foreach(Artist artist in oldestArtist)
            {
                Console.WriteLine(artist.RealName);
                Console.WriteLine(artist.ArtistName);
                Console.WriteLine(artist.Age);
            }

            //(Optional) Display the Group Name of all groups that have at least one member not from New York City.

            IEnumerable<Group> notNY = Groups.Where(group => group.Members.Any(team => team.Hometown != "New York City"));
            foreach(Group group in notNY)
            {
                Console.WriteLine(group.GroupName);
            }

            //(Optional) Display the artist names of all members of the group 'Wu-Tang Clan'.

            IEnumerable<string> WuTangClan = Artists.Join(Groups, artist => artist.GroupId, group => group.Id, (artist, group) => 
            new{artistWuTangClan = artist.ArtistName, groupWuTangClan = group.GroupName}).Where(group => group.groupWuTangClan == "Wu-Tang Clan").Select(name => name.artistWuTangClan);
            foreach(string artist in WuTangClan)
            {
                Console.WriteLine(artist);
            }

	        Console.WriteLine(Groups.Count);
        }
    }
}
