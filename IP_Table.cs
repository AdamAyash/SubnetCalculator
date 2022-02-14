public class IP_Table
{
	private string ip;
	private string newSubnetMask;

	private string[] ipTableArray;

	private int subnetNumber;
	private int numberOfBits_Hosts;
	private int numberOfBits_Subnetworks;

	public IP_Table(string ip, int subnetNumber,int numberOfBits)
	{
		this.ip = ip;
		this.subnetNumber = subnetNumber;
		this.ipTableArray = new string[subnetNumber];
		this.numberOfBits_Hosts = 8 - numberOfBits;
		this.numberOfBits_Subnetworks = numberOfBits;

		GenerateSubNetwork();
		GetNewSubnetMask();
	}

	public string[] IPTableArray
	{
		get
		{
			return this.ipTableArray;
		}
	}
	public string NewSubnetMask
	{
		get
		{
			return this.newSubnetMask;
		}
	}

	private void GenerateSubNetwork()
	{
		for (int i = 0; i < this.subnetNumber; i++)
		{
			int currentByteMin = int.Parse(BinaryCalculator.DecimalToBinaryNumber(i) + new string('0', this.numberOfBits_Hosts));
			int currentByteMax = int.Parse(BinaryCalculator.DecimalToBinaryNumber(i) + new string('1', this.numberOfBits_Hosts));
			currentByteMin++;
			currentByteMax--;
			this.ipTableArray[i] = BinaryCalculator.BinaryToDecimalNumber(currentByteMin.ToString()).ToString() + "-" + BinaryCalculator.BinaryToDecimalNumber(currentByteMax.ToString()).ToString();
		}
	}

	private void GetNewSubnetMask()
	{
		this.newSubnetMask = new string('1', numberOfBits_Subnetworks) + new string('0', numberOfBits_Hosts);
		this.newSubnetMask = BinaryCalculator.BinaryToDecimalNumber(this.newSubnetMask).ToString();
	}
}
