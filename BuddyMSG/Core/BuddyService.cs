using System;

namespace BuddyMSG
{
	public static class BuddyService
	{
		public const string BuddyApplicationName     = "BuddyMSG";
		public const string BuddyApplicationPassword = "45F4CE02-BEEC-46F7-A2AC-F747A8318CBE";

        public static Buddy.BuddyClient BuddyClientService = new Buddy.BuddyClient(BuddyService.BuddyApplicationName, BuddyService.BuddyApplicationPassword);
	}
}

