import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SecThirdComponent } from './sec-third.component';

describe('SecThirdComponent', () => {
  let component: SecThirdComponent;
  let fixture: ComponentFixture<SecThirdComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SecThirdComponent]
    });
    fixture = TestBed.createComponent(SecThirdComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
