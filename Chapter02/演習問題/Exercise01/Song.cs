using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    class Song {
        string title;
        string artistName;
        int length;

        public string Title { get => title; set => title = value; }
        public string ArtistName { get => artistName; set => artistName = value; }
        public int Length { get => length; set => length = value; }

        public Song(string title,string artistName,int length){
            Title = title;
            ArtistName = artistName;
            Length = length;
            
        }
    }
}
