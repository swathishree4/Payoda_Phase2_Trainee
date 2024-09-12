import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-dailytask',
  standalone: true,
  imports: [CommonModule,FormsModule],
  templateUrl: './dailytask.component.html',
  styleUrl: './dailytask.component.css'
})
export class DailytaskComponent {
  lists:Dress[]=[
    {ITEM:"kurta",PRICE:2150,STOCK:3,RATING:4,IMAGE:"public/kurta.jfif"},
    {ITEM:"Party Wear",PRICE:3000,STOCK:4,RATING:3,IMAGE:"public/party wear.jfif"},
    {ITEM:"T-Shirt",PRICE:500,STOCK:3,RATING:3,IMAGE:"public/t shirt.jfif"}
  ]
  cartprod:Dress[]= [];
    add(prod:Dress)
    {
      if ( prod.STOCK > 0) {
        this.cartprod.push(prod);  
        // prod.STOCK--;  
        console.log('Product added to cart:', prod);
      } 
      else {
        console.error('Out of stock or no product selected.');
      }
    }
    buyprod:Dress[]=[];
    buy(prod:Dress)
    {
      if (prod.STOCK > 0) {
        this.buyprod.push(prod);  
        prod.STOCK--;  
        console.log('Product added to cart:', prod);
      } 
      else {
        console.error('Out of stock or no product selected.');
      }
    }
    userstatus:string='guest'
    status(s:string){
      this.userstatus=s
    }

    remove(){
      
    }
 
}
class Dress{
  ITEM:string=''
  PRICE:number=0
  STOCK:number=0
  RATING:number=0
  IMAGE:string=''
}
