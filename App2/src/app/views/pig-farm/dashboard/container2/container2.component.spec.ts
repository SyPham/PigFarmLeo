/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { Container2Component } from './container2.component';

describe('Container2Component', () => {
  let component: Container2Component;
  let fixture: ComponentFixture<Container2Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ Container2Component ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(Container2Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
