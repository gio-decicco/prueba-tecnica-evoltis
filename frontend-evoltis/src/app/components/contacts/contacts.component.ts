import { Component } from '@angular/core';
import { InputTextModule } from 'primeng/inputtext';
import { PanelModule } from 'primeng/panel';
import { InputTextareaModule } from 'primeng/inputtextarea';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-contacts',
  standalone: true,
  imports: [PanelModule, InputTextModule, InputTextareaModule, ReactiveFormsModule],
  templateUrl: './contacts.component.html',
  styleUrl: './contacts.component.scss'
})
export class ContactsComponent {
  form: FormGroup = new FormGroup({});

  constructor(private fb: FormBuilder) {
    this.form = this.fb.group({
      name: ['Giovanni Decicco Ominetti'],
      email: ['giovannideciccoominetti@gmail.com'],
      skills: ['Angular, .NET, DevOps, Ionic, Kotlin, Lazarus, IIS, Docker']
    });
  }
}
