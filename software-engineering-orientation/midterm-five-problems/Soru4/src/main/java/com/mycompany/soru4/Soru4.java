package com.mycompany.soru4;

import java.util.Scanner;

//Dikdörtgenin çevresini ve alanine hesaplama

public class Soru4 {
    public static void main(String[] args){
        Scanner scn=new Scanner(System.in);
        
        System.out.print("Birinci kenari giriniz: ");
        int birinciKenar=scn.nextInt();
        
        System.out.print("Ikinci kenari giriniz: ");
        int ikinciKenar=scn.nextInt();
        
        double alan=birinciKenar*ikinciKenar;
        double cevre=2*(birinciKenar+ikinciKenar);
        System.out.println("Alan= "+alan);
        System.out.println("Cevre= "+cevre);
    }
    
}
