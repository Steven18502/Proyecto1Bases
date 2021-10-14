import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExitpageComponent } from './exitpage.component';

describe('ExitpageComponent', () => {
  let component: ExitpageComponent;
  let fixture: ComponentFixture<ExitpageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ExitpageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ExitpageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
