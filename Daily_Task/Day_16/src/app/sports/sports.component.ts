import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';

@Component({
  selector: 'app-sports',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './sports.component.html',
  styleUrl: './sports.component.css'
})
export class SportsComponent {
    lstsport:sports[]=[
        {Captian:"Virat",No_of_players:11,Score:1120,Logo:"public/cricket.jfif"},
        {Captian:"Larens",No_of_players:13,Score:4120,Logo:"public/hockey.jfif"},
        {Captian:"Joe Doe",No_of_players:16,Score:2120,Logo:"public/tenis.jfif"}
    ]
    text:string= "welcome!!!"
    name?:string
    player?:number
    points?:number
    answer?:string
    text1?:string
    display(obj:sports){
      this.name=obj.Captian;
      this.player=obj.No_of_players;
      this.points=obj.Score;
      this.answer="The Captian is "+this.name+", the players in the team are "+this.player+" and the score is "+this.points;
    }
    show(event:any)
    {
      this.text1=(event.target.value)
    }
   
}

class sports{
  Captian?:string
  No_of_players?:number
  Score?:number
  Logo?:string
}

