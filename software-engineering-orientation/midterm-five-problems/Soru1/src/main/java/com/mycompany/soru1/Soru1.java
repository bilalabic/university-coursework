package com.mycompany.soru1;

import java.util.Scanner;

//Taban ve Yuksekliği bilinen bir üçgenin alanının hesaplama


public class Soru1 {
   public static void main(String[] args){
       Scanner scn=new Scanner(System.in);
       
       System.out.print("Taban uzunlugunu giriniz: ");
       double tabanUzunlugu=scn.nextDouble();
       
       System.out.print("Yukseklik uzunlugunu giriniz: ");
       double yukseklikUzunlugu=scn.nextDouble();
       
       double alan=(tabanUzunlugu*yukseklikUzunlugu)/2;
       
       System.out.print("Alan= "+alan);
   }
}
