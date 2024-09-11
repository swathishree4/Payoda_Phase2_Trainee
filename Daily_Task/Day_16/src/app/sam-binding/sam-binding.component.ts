import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-sam-binding',
  standalone: true,
  imports: [FormsModule,CommonModule],
  templateUrl: './sam-binding.component.html',
  styleUrl: './sam-binding.component.css'
})
export class SamBindingComponent {
    fname:string ="Payoda"
    lname:string ="Organization"
    imageurl:string ="public/nature.jfif"
    text:string= "welcomee!!!"
    value:string=" ";
    count:number=0;
    butval:boolean=false;
    counter()
    {
      this.count++;
    }

    display(){
      this.butval=true;
      this.fname="swathi";
      this.lname="shree";
    }

    show(event:any)
    {
      this.text=(event.target.value)
    }
}
