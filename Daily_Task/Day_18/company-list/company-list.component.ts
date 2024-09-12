import { Component } from '@angular/core';
import { ApiService } from '../api.service';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
@Component({
  selector: 'app-company-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './company-list.component.html',
  styleUrl: './company-list.component.css'
})
export class CompanyListComponent {
  data:any;
  constructor(private apiser:ApiService,private router:Router)
  {

  }

  ngOnInit():void{
    this.apiser.get().subscribe(
      (response)=>{
        this.data=response;
      }
    );
  }

  viewDetails(id: number): void {
    this.router.navigate(['/company', id]); 
  }

  viewEdit(id: number): void {
    this.router.navigate(['/update', id]);  
  }

  deleteCompany(id: number): void{
    this.router.navigate(['/delete-company',id]);
 }

 addcompany():void{
  this.router.navigate(['/add']);
 }
}
