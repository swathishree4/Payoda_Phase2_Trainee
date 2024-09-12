import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CompanyupdateComponent } from './companyupdate.component';

describe('CompanyupdateComponent', () => {
  let component: CompanyupdateComponent;
  let fixture: ComponentFixture<CompanyupdateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CompanyupdateComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CompanyupdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
