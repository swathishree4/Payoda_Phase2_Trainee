import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { ApiService } from '../api.service';
import { Company } from '../companydetail/Company';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-companyupdate',
  standalone: true,
  imports: [CommonModule,FormsModule],
  templateUrl: './companyupdate.component.html',
  styleUrl: './companyupdate.component.css'
})
export class CompanyupdateComponent {
      company:Company={companyId:0,companyName:''};
      constructor(private apiser:ApiService,private router:Router){
        
      }
      onSubmit():void{
          this.apiser.postcomp(this.company).subscribe(
            (response)=>{
              console.log('company added successfully',response);
              this.router.navigate(['/']);
            }
          );
      }
}
