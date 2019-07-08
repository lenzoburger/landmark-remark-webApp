/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { RemarkComponent } from './remark.component';

describe('RemarkComponent', () => {
  let component: RemarkComponent;
  let fixture: ComponentFixture<RemarkComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RemarkComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RemarkComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});