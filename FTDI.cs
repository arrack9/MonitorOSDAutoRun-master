/*
 * Created by SharpDevelop.
 * User: Pingyao.Chen
 * Date: 2018/1/10
 * Time: 下午 01:26
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;

namespace MonitorOSDAutoRun
{
	/// <summary>
	/// Description of FTDI.
	/// </summary>
	public class FTDI
	{
		[DllImport("FTC_I2C.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]        
        private static extern bool I2C_Writetable([In, Out] int[] iData, [In] int iLength, [In] int busSpeed);
        [DllImport("FTC_I2C.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern bool I2C_Readtable([In, Out] int[] iData, [In] int iLength, [In] int busSpeed);
        
        int checksum;
        int[] Language_Index = new int[] { 0x6E, 0x51, 0x84, 0x03, 0xCC, 0x00, 0x00, 0x00};
        int[] Menu_Index = new int[] { 0x6E, 0x51, 0x84, 0x03, 0x99, 0x00, 0x00, 0x00};
        int[] Read_Addr = new int[] {  0x6E, 0x51, 0x82, 0x01, 0x99, 0x00};
        int[] Data = new int[16];
        bool status = false;
     
		public FTDI()
		{
		}
		
		private int cacul_Checksum(int[] array)
        {
        	for(int i = 0; i < array.Length; i++)
        	{
        		 checksum ^= array[i];
        	}
        	return checksum;
        }
		
		public void SetOSDLanguage(int adjLanguage)
        {			
			Language_Index[6] = adjLanguage;
			Language_Index[7] = cacul_Checksum(Language_Index);
			status = I2C_Writetable(Language_Index, Language_Index.Length, 30);  
		}
		
		public void SetOSDSisplayDirectly(int menuIndex)
		{
			Menu_Index[6] = menuIndex;
			Menu_Index[7] = cacul_Checksum(Menu_Index);
			status = I2C_Writetable(Menu_Index, Menu_Index.Length, 30);
		}
		
		public int GetOSDMenuIndex()
		{
			Read_Addr[5] = cacul_Checksum(Read_Addr);
			status = I2C_Writetable(Read_Addr, Read_Addr.Length, 30);	
			Thread.Sleep(100);	
			status = I2C_Readtable(Data, Data.Length, 30);			
			return Data[1];
		}
		
		public int[] GetOSDMenuArray(int menuIndex)
		{
			SetOSDLanguage(6);
			Read_Addr[5] = cacul_Checksum(Read_Addr);
			status = I2C_Writetable(Read_Addr, Read_Addr.Length, 30);	
			Thread.Sleep(100);	
			status = I2C_Readtable(Data, Data.Length, 30);
			
			return Data;
		}
	}
}
