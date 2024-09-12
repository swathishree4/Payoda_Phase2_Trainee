import { Component } from '@angular/core';
import { Company } from '../companydetail/Company';
import { ApiService } from '../api.service';
import { ActivatedRoute, Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-companydelete',
  standalone: true,
  imports: [CommonModule,FormsModule],
  templateUrl: './companydelete.component.html',
  styleUrl: './companydelete.component.css'
})
export class CompanydeleteComponent {
  constructor(private apiser:ApiService,private router:Router,private route:ActivatedRoute)
      {

      }
      ngOnInit():void{
        const id = +this.route.snapshot.params['id'];
        if (confirm("Are you sure to delete")){
           this.apiser.deletecomp(id).subscribe(
          
            (response)=>
            {
              console.log("Company Removed");
             
            }
           )
          }
          else{
            this.router.navigate(['/'])
          }
      }


}