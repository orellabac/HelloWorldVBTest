
import { NgModule, CUSTOM_ELEMENTS_SCHEMA  } from '@angular/core';
import { CommonModule } from '@angular/common';
import { WebMapKendoModule } from '@mobilize/winforms-components';
import { WebMapService, WebMapModule } from '@mobilize/angularclient';

import * as TestProject from './components/test-project';

@NgModule({
  imports: [
    CommonModule,
    WebMapKendoModule,
    WebMapModule,
  ],
  exports: [
    TestProject.Form1Component,
  ],
  declarations: [
    TestProject.Form1Component,
  ],
  entryComponents: [
    TestProject.Form1Component,
  ],
   providers: [WebMapService],
   schemas: [ CUSTOM_ELEMENTS_SCHEMA ]
})
export class TestProjectModule { }

