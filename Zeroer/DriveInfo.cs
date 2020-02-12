using System;
using System.Management;

namespace Zeroer
{
	/// <summary>
	/// Summary description for DriveInfo.
	/// </summary>
	public class DriveInfo
	{
		public const long KILOBYTE = 1024;
		public const long MEGABYTE = KILOBYTE * 1024;
		public const long GIGABYTE = MEGABYTE * 1024;
		public const long TERABYTE = GIGABYTE * 1024;

		public enum DriveTypeEnum :int 
		{
			Unknown = 0, 
			NoRootDir = 1,
			Removeable = 2,
			LocalDisk = 3,
			NetworkDisk = 4,
			CompactDisk = 5,
			RamDisk = 6 
		};

		public char DriveLetter;
		public string DriveName;
		public long FreeSpace;
		public long Size;
		public DriveTypeEnum DriveType;

		public DriveInfo(char DriveLetter)
		{
			this.DriveLetter = DriveLetter;
			this.DriveName = DriveLetter.ToString() + ":";

			ManagementObjectCollection myMOC = 
				(
					new ManagementObjectSearcher
						(
							new SelectQuery("SELECT * FROM Win32_LogicalDisk WHERE deviceID = '"+this.DriveName+"'"	)
						)
				).Get();
			foreach (ManagementObject myMO in myMOC)
			{
				this.FreeSpace = long.Parse(myMO.Properties["FreeSpace"].Value.ToString());
				this.Size = long.Parse(myMO.Properties["Size"].Value.ToString());
				this.DriveType = (DriveTypeEnum)int.Parse(myMO.Properties["DriveType"].Value.ToString());
			}
		}

		public static string GetFriendlyBytes ( long bytes ) 
		{
			if ( bytes < KILOBYTE ) 
				return bytes.ToString() + "B";
			else if ( bytes < MEGABYTE ) 
				return (bytes/KILOBYTE).ToString() + "KB";
			else if ( bytes < GIGABYTE ) 
				return (bytes/MEGABYTE).ToString() + "MB";
			else if ( bytes < TERABYTE ) 
				return (bytes/GIGABYTE).ToString() + "GB";
			else
				return (bytes/TERABYTE).ToString() + "TB";
		}

	}
}
