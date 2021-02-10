using System;
using System.IO;

namespace Zeroer
{
    /// <summary>
    /// Summary description for ZeroFile.
    /// </summary>
    public class ZeroFile
    {
        public char DriveLetter;
        public string DriveName;
        public string FileName;
        public bool Exists;
        public long Size;

        public bool Canceled;

        private FileInfo info;

        public ZeroFile(char DriveLetter)
        {
            this.Canceled = false;
            this.DriveLetter = DriveLetter;
            this.DriveName = DriveLetter.ToString() + ":";
            this.FileName = this.DriveName + "\\zeroer.000";
            info = new FileInfo(this.FileName);
            if (info.Exists)
            {
                this.Exists = true;
                this.Size = info.Length;
            }
            else
            {
                this.Exists = false;
                this.Size = 0;
            }
        }

        public long GetSize(char DriveLetter)
        {
            ZeroFile zf = new ZeroFile(DriveLetter);
            return zf.Size;
        }

        public void ZeroFreeSpace(bool withOnes, System.Windows.Forms.ProgressBar progressBar)
        {
            this.FileName = this.DriveName + "\\zeroer.$$$";
            if (File.Exists(this.FileName)) File.Delete(this.FileName);
            DriveInfo driveInfo = new DriveInfo(this.DriveLetter);
            long megaBytes = driveInfo.FreeSpace / DriveInfo.MEGABYTE;
            Create(megaBytes, withOnes, progressBar);
            if (File.Exists(this.FileName)) File.Delete(this.FileName);
        }

        public void Create(long MegaBytes, bool withOnes)
        {
            this.Create(MegaBytes, withOnes, null);
            File.Delete(this.FileName);
        }

        public void Create(long MegaBytes, bool withOnes, System.Windows.Forms.ProgressBar progressBar)
        {
            byte[] megaByte = new byte[DriveInfo.MEGABYTE];
            byte[] megaByteOnes = new byte[DriveInfo.MEGABYTE];
            for (long c = 0; c < DriveInfo.MEGABYTE; c++)
            {
                megaByte[c] = 0;
                megaByteOnes[c] = 0xff;
            }
            this.Size = MegaBytes * DriveInfo.MEGABYTE;

            if (progressBar != null)
            {
                progressBar.Maximum = (int)MegaBytes;
                progressBar.Value = 0;
            }
            FileStream fs = new FileStream(this.FileName, FileMode.CreateNew);
            for (long c = 0; c < MegaBytes && !Canceled; c++)
            {
                if (withOnes)
                {
                    fs.Write(megaByteOnes, 0, (int)DriveInfo.MEGABYTE);
                    fs.Position -= (int)DriveInfo.MEGABYTE;
                }
                if (!Canceled)
                {
                    fs.Write(megaByte, 0, (int)DriveInfo.MEGABYTE);
                    if (progressBar != null)
                    {
                        progressBar.Value = (int)(c + 1);
                        System.Windows.Forms.Application.DoEvents();
                    }
                }
            }
            fs.Close();

            this.Exists = true;
        }

        public void Delete()
        {
            File.Delete(this.FileName);
            this.Exists = false;
            this.Size = 0;
        }

        public void Expand(long MegaBytes, bool withOnes)
        {
            this.Expand(MegaBytes, withOnes, null);
        }

        public void Expand(long MegaBytes, bool withOnes, System.Windows.Forms.ProgressBar progressBar)
        {
            byte[] megaByte = new byte[DriveInfo.MEGABYTE];
            byte[] megaByteOnes = new byte[DriveInfo.MEGABYTE];
            for (long c = 0; c < DriveInfo.MEGABYTE; c++)
            {
                megaByte[c] = 0;
                megaByteOnes[c] = 0xff;
            }
            this.Size += MegaBytes * DriveInfo.MEGABYTE;

            if (progressBar != null)
            {
                progressBar.Maximum = (int)MegaBytes;
                progressBar.Value = 0;
            }
            FileStream fs = new FileStream(this.FileName, FileMode.Append);
            for (long c = 0; c < MegaBytes && !Canceled; c++)
            {
                if (withOnes)
                {
                    fs.Write(megaByteOnes, 0, (int)DriveInfo.MEGABYTE);
                    fs.Position -= (int)DriveInfo.MEGABYTE;
                }
                if (!Canceled)
                {
                    fs.Write(megaByte, 0, (int)DriveInfo.MEGABYTE);
                    if (progressBar != null)
                    {
                        progressBar.Value = (int)(c + 1);
                        System.Windows.Forms.Application.DoEvents();
                    }
                }
            }
            fs.Close();
        }

        public void Shrink(long MegaBytes)
        {
            this.Size -= MegaBytes * DriveInfo.MEGABYTE;
            if (this.Size > 0)
            {
                FileStream fs = new FileStream(this.FileName, FileMode.Open);
                fs.SetLength(this.Size);
                fs.Close();
            }
            else
            {
                this.Delete();
            }
        }
    }
}
