using System;
using System.Collections.Generic;
using Camelot.Services.EventArgs;
using Camelot.Services.Models;

namespace Camelot.Services.Interfaces
{
    public interface IDirectoryService
    {
        event EventHandler<SelectedDirectoryChangedEventArgs> SelectedDirectoryChanged;

        string SelectedDirectory { get; set; }

        bool Create(string directory);
        
        DirectoryModel GetParentDirectory(string directory);
        
        IReadOnlyCollection<DirectoryModel> GetDirectories(IReadOnlyCollection<string> directories);

        IReadOnlyCollection<DirectoryModel> GetChildDirectories(string directory);

        bool CheckIfExists(string directory);

        string GetAppRootDirectory();

        IReadOnlyCollection<string> GetFilesRecursively(string directory);

        void RemoveRecursively(string directory);

        void Rename(string directoryPath, string newName);
    }
}