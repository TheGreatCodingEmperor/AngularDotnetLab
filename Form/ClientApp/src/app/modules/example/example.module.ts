import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ExampleRoutingModule } from './example-routing.module';
import { ExampleHomeComponent, InputGroupAddOn, InputGroupContainer, RWD } from './views/example-home/example-home.component';
import { SharedModule } from '../shared/shared.module';


@NgModule({
  declarations: [
    ExampleHomeComponent,

    RWD,
    InputGroupContainer,
    InputGroupAddOn
  ],
  imports: [
    SharedModule,
    CommonModule,
    ExampleRoutingModule
  ]
})
export class ExampleModule { }
