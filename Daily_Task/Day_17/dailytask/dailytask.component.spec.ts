import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DailytaskComponent } from './dailytask.component';

describe('DailytaskComponent', () => {
  let component: DailytaskComponent;
  let fixture: ComponentFixture<DailytaskComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DailytaskComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DailytaskComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
