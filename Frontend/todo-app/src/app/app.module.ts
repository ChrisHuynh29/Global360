import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { ToDoComponent } from './feature/to-do/to-do.component';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [

  ],
  imports: [
    BrowserModule,
    AppComponent,
    ToDoComponent,
    FormsModule
  ],
  providers: [],
})
export class AppModule { }