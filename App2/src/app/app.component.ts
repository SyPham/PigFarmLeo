import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { TranslateService } from '@ngx-translate/core';
import { environment } from 'src/environments/environment';
import { VersionCheckService } from './_core/_service/version-check.service';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  titleKey = 'New Generation Ranch System';
  constructor(
    private versionCheckService: VersionCheckService,
    private title:Title,
    private translate:TranslateService
    ) {
  }
  ngOnInit(): void {
    this.translate.get(this.titleKey).subscribe(name=>{
      this.title.setTitle(name);
    });
    this.versionCheckService.initVersionCheck(environment.versionCheckURL);
  }
}


