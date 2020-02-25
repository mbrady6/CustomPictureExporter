using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections.ObjectModel;
using System.Windows.Forms;

using PictureGetter.Model;
using PictureGetter.Helper;

namespace PictureGetter.ViewModel
{
    public class ViewModelMain : ViewModelBase
    {
        public ViewModelMain()
        {
            SelectSourceDirectoryCommand = new RelayCommand(SelectSourceDirectory);
            SelectDestinationDirectoryCommand = new RelayCommand(SelectDestinationDirectory);
            EngageCopyCommand = new RelayCommand(EngageCopy);

            CopyDetails = new CopyDetails();
        } 

        public RelayCommand SelectSourceDirectoryCommand { get; set; }
        private void SelectSourceDirectory(object obj)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                DialogResult result = dialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(dialog.SelectedPath))
                {
                    CopyDetails.Source = dialog.SelectedPath;
                    DirectoryInfo directoryInfo = new DirectoryInfo(CopyDetails.Source);
                    SourceMediaFiles = Utility.GetFileListFromDirectory(directoryInfo);
                }
            }
        }

        public RelayCommand SelectDestinationDirectoryCommand { get; set; }
        private void SelectDestinationDirectory(object obj)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                DialogResult result = dialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(dialog.SelectedPath))
                {
                    CopyDetails.Destination = dialog.SelectedPath;
                }
            }
        }

        public RelayCommand EngageCopyCommand { get; set; }
        private void EngageCopy(object obj)
        {
            MessageBox.Show(CopyDetails.ToString());
        }

        private CopyDetails _copyDetails;
        public CopyDetails CopyDetails
        {
            get
            {
                return _copyDetails;
            }

            set
            {
                _copyDetails = value;
                RaisePropertyChangedEvent("CopyDetails");
            }
        }

        private ObservableCollection<MediaFile> _sourceMediaFiles;
        public ObservableCollection<MediaFile> SourceMediaFiles
        {
            get { return _sourceMediaFiles; }
            set { _sourceMediaFiles = value;
                RaisePropertyChangedEvent("SourceMediaFiles");
            }
        }
    }
}
