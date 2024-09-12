import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CompanydeleteComponent } from './companydelete.component';

describe('CompanydeleteComponent', () => {
  let component: CompanydeleteComponent;
  let fixture: ComponentFixture<CompanydeleteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CompanydeleteComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CompanydeleteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
