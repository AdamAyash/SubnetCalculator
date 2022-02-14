using System;
public class SubnetCalculator
{
	static void Main()
	{
		Console.Clear();
		Console.Title = "Subnet Calculator";
		Console.WindowHeight = 40;
		Console.WindowWidth = 120;

		while (true)
		{
			string ip;
			string ipClass;
			string defaultSubnetMask;
			string newSubnetMask;

			byte subnetworkNumber;
			byte numberOfBits;

			IP_Table ipTable;

			Console.Write("Please, enter ip address: ");
			ip = Console.ReadLine();
			Console.Write("Please, enter the number of desired subnetworks: ");
			subnetworkNumber = byte.Parse(Console.ReadLine());
			numberOfBits = GetNumberOfBits(subnetworkNumber);

			//Reminder: Should implement ip validation!
			ipClass = GetIPClass(ip);
			ipTable = new IP_Table(ip, subnetworkNumber, numberOfBits);
			defaultSubnetMask = GetDefaultSubnetMask(ipClass);
			newSubnetMask = ipTable.NewSubnetMask;
			newSubnetMask = defaultSubnetMask.Replace("0", ipTable.NewSubnetMask);

			Console.WriteLine("The entered ip is class: {0}", ipClass);
			Console.WriteLine("The default subnet mask is: {0}", defaultSubnetMask);
			Console.WriteLine("The new subnet mask is: {0}",newSubnetMask);
			Console.WriteLine();
			PrintIpTable(ipTable);

			Console.ReadLine();
		}
	}

	static string GetIPClass(string ip)
	{
		string[] octetArray = ip.Split('.');
		int firstOctet = int.Parse(octetArray[0]);

		if (firstOctet >= 1 && firstOctet <= 126)
		{
			return "A";
		}
		else if (firstOctet >= 128 && firstOctet <= 191)
		{
			return "B";
		}
		else if (firstOctet >= 192 && firstOctet <= 223)
		{
			return "C";
		}
		else
		{
			return "Invalid ip address please try again";
		}
	}

	static string GetDefaultSubnetMask(string ipClass)
	{
		if (ipClass == "A")
		{
			return "255.0.0.0";
		}
		else if (ipClass == "B")
		{
			return "255.255.0.0";
		}
		else if (ipClass == "C")
		{
			return "255.255.255.0";
		}
		else
		{
			throw new Exception();
		}
	}
	static byte GetNumberOfBits(byte subnetworkNumber)
	{
		byte numberOfBytes = 0;
		while (Math.Pow(2, numberOfBytes) < subnetworkNumber)
		{
			numberOfBytes++;
		}
		return numberOfBytes;
	}
	static void PrintIpTable(IP_Table ipTable)
	{
		byte counter = 1;
		foreach (var item in ipTable.IPTableArray)
		{
			Console.WriteLine(counter + "." + " " + item);
			counter++;
		}
	}

}
