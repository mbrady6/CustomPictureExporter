using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureGetter.Model
{
    public class MediaFile
    {
        public MediaFile(string _path, string _name, string _extension, DateTime _createdDate )
        {
            Path = _path;
            Name = _name;
            Extension = _extension;
            CreatedDate = _createdDate;
        }

        public string Path { get; set;}

        public string Name { get; set; }

        public string Extension { get; set; }

        public DateTime CreatedDate { get; set; }

        private string[] ValidFileTypes = new[] { ".jpg", ".gif", ".png", ".bmp", ".mp4" };

        public bool IsValidType()
        {
            bool valid = default(bool);

            if(ValidFileTypes.Contains(Extension))
            {
                valid = true;
            }

            return valid;
        }
    }
}
