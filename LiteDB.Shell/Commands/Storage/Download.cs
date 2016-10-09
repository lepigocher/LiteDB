﻿using System;

namespace LiteDB.Shell.Commands
{
    internal class FileDownload : BaseStorage, IShellCommand
    {
        public bool IsCommand(StringScanner s)
        {
            return this.IsFileCommand(s, "download");
        }

        public BsonValue Execute(LiteEngine engine, StringScanner s)
        {
            var fs = new LiteStorage(engine);
            var id = this.ReadId(s);
            var filename = s.Scan(@"\s*.*").Trim();

            var file = fs.FindById(id);

            if (file != null)
            {
                file.SaveAs(filename);

                return file.AsDocument;
            }

            return false;
        }
    }
}