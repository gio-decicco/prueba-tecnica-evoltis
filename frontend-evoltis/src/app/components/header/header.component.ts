import { Component, OnInit } from '@angular/core';
import { MenubarModule } from 'primeng/menubar';
import { MenuItem } from 'primeng/api';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [MenubarModule],
  templateUrl: './header.component.html',
  styleUrl: './header.component.scss'
})
export class HeaderComponent implements OnInit{
  items: MenuItem[] | undefined;

  ngOnInit() {
      this.items = [
          {
              label: 'Clients',
              icon: 'pi pi-users',
              routerLink: '/clients'
          },
          {
              label: 'Services',
              icon: 'pi pi-list-check',
              routerLink: '/services'
          },
          {
              label: 'Contact',
              icon: 'pi pi-envelope',
              routerLink: '/contact'
          }
      ]
  }
}
