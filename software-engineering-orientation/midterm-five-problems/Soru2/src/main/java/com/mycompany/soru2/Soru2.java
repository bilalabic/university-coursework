package com.mycompany.soru2;

import java.util.Scanner;

//Girilen iki sayıyı karşılaştırma

public class Soru2 {
    public static void main(String[] args){
        Scanner scn=new Scanner(System.in);
        
        System.out.print("Birinci sayiyi giriniz: ");
        double birinciSayi=scn.nextDouble();
        
        System.out.print("Ikinci sayiyi giriniz: ");
        double ikinciSayi=scn.nextDouble();
        
        if (birinciSayi<ikinciSayi) {
            System.out.print("Birinci sayi kucuktur ikinci sayidan!");
        }
        else if (birinciSayi>ikinciSayi) {
            System.out.print("Birinci sayi buyuktur ikinci sayidan!");
        }
        else{
            System.out.print("Iki sayi birbirine esittir.");
        }
    }
    
    
}
