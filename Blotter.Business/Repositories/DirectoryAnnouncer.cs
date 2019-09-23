using Blotter.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blotter.Business.Repositories
{
    public class DirectoryAnnouncer : IAnnouncer
    {
        private readonly string _directory;

        public DirectoryAnnouncer(string directory)
        {
            _directory = directory;
        }
        public string Announce() => _directory;
    }
}
