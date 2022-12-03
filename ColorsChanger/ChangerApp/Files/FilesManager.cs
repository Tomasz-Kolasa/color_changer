﻿using ColorsChanger.ChangerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorsChanger.ChangerApp.Files
{
    public class FilesManager
    {
        private readonly string _projectPath;
        private string[] _filesPaths = new string[] { };

        private readonly ColorReader _colorReader;
        private readonly ColorReplacer _colorReplacer;

        public FilesManager()
        {
            _projectPath = Path.Combine(
                Directory.GetParent(
                    Environment.CurrentDirectory).Parent.Parent.FullName,
                "ChangerApp","Files","src");

            _filesPaths = Directory.GetFiles(_projectPath, "*.*", SearchOption.AllDirectories);

            _colorReader = new ColorReader(this);
            _colorReplacer = new ColorReplacer(this);
        }

        public List<UniqueColor> GetUniqueColorsList()
        {
            return _colorReader.GetUniqueColorsList();
        }

        public List<UniqueColor> BuildAndGetUniqueColors()
        {
            _colorReader.BuildUniqueColorsList();
            return _colorReader.GetUniqueColorsList();
        }

        public void ReplaceColorsInFiles()
        {
            _colorReplacer.ReplaceColorsInFiles();
        }

        public string[] GetProjectFilesPaths()
        {
            return _filesPaths;
        }

        public string GetProjectPath()
        {
            return _projectPath;
        }
    }
}
