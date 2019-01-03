using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace FolderExplorer
{
    public class Folder
    {
        private DirectoryInfo _folder;
        private ObservableCollection<Folder> _subFolders;
        private ObservableCollection<FileInfo> _files;

        public Folder()
        {
            this.FullPath = @"C:\Users\COLLIN\Desktop\MDS-AFTEC\2018-2019";
        }

        public string Name
        {
            get
            {
                return this._folder.Name;
            }
        }

        public string FullPath
        {
            get
            {
                return this._folder.FullName;
            }

            set
            {
                if (Directory.Exists(value))
                {
                    this._folder = new DirectoryInfo(value);
                }
                else
                {
                    throw new ArgumentException("must exist", "fullPath");
                }
            }
        }

        public ObservableCollection<FileInfo> Files
        {
            get
            {
                if (this._files == null)
                {
                    this._files = new ObservableCollection<FileInfo>();

                    FileInfo[] fi = this._folder.GetFiles();

                    for (int i = 0; i < fi.Length; i++)
                    {
                        this._files.Add(fi[i]);
                    }
                }

                return this._files;
            }
        }

        public ObservableCollection<Folder> SubFolders
        {
            get
            {
                if (this._subFolders == null)
                {
                    this._subFolders = new ObservableCollection<Folder>();

                    DirectoryInfo[] di = this._folder.GetDirectories();

                    for (int i = 0; i < di.Length; i++)
                    {
                        Folder newFolder = new Folder();
                        newFolder.FullPath = di[i].FullName;
                        this._subFolders.Add(newFolder);
                    }
                }

                return this._subFolders;
            }
        }
    }
}

