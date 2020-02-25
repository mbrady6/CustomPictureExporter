using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PictureGetter.Helper;

namespace PictureGetter.Model
{
    public class CopyDetails : ObservableObject
    {
        private string _source;
        public string Source
        {
            get
            {
                return _source;
            }
            set
            {
                _source = value;
                RaisePropertyChangedEvent("Source");
            }
        }

        private string _destination;
        public string Destination
        {
            get
            {
                return _destination;
            }
            set
            {
                _destination = value;
                RaisePropertyChangedEvent("Destination");
            }
        }

        private DateTime _lastCopyDate = DateTime.Now;
        public DateTime LastCopyDate
        {
            get
            {
                return _lastCopyDate;
            }
            set
            {
                _lastCopyDate = value;
                RaisePropertyChangedEvent("LastCopyDate");
            }
        }

        public override string ToString()
        {
            return "Source: " + Source + "\n" + "Destination: " + Destination + "\n" + LastCopyDate.ToString();
        }
    }
}
