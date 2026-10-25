package com.mycompany.soru5;
import java.util.Scanner;

//Girilen sayının çift mi tek mi olduğunu bulma

public class Soru5 {
    public static void main(String[] args){
        Scanner scn=new Scanner(System.in);
        
        System.out.print("Sayi giriniz: ");
        int sayi=scn.nextInt();
        
        if (sayi%2==0) {
            System.out.println("Sayi Cifttir.");
        }
        else{
            System.out.println("Sayi Tektir");
        }
       
    }
    
}
