import { Component } from '@angular/core';
import { ApiService } from '../api.service';
import { ActivatedRoute } from '@angular/router';
import { Company } from './Company';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-companydetail',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './companydetail.component.html',
  styleUrl: './companydetail.component.css'
})
export class CompanydetailComponent {
  company :Company | undefined
    constructor (private apiser:ApiService,private ROUTE:ActivatedRoute){

    }
    ngOnInit():void{
      const id=+this.ROUTE.snapshot.params['id'];
      this.apiser.getbyid(id).subscribe(
        (response)=>{
          this.company=response
        }
      )
     }
}
