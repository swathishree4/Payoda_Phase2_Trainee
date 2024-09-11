import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SamBindingComponent } from './sam-binding.component';

describe('SamBindingComponent', () => {
  let component: SamBindingComponent;
  let fixture: ComponentFixture<SamBindingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SamBindingComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SamBindingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
