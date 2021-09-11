import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { DataService } from 'src/app/Service/data.service';
import Swal from 'sweetalert2'
@Component({
  selector: 'app-location',
  templateUrl: './location.component.html',
  styleUrls: ['./location.component.css']
})
export class LocationComponent implements OnInit {
  
  submitted = false;
  location: any;
  constructor(private _data : DataService) { }

  form = new FormGroup({
    AngularV1x: new FormControl('', [Validators.required,Validators.max(60), Validators.min(0)]),
    AngularV1y: new FormControl('', [Validators.required,Validators.max(60), Validators.min(0)]),
    LeftV2x: new FormControl('', [Validators.required,Validators.max(60), Validators.min(0)]),
    LeftV2y: new FormControl('', [Validators.required,Validators.max(60), Validators.min(0)]),
    RightV3x: new FormControl('', [Validators.required,Validators.max(60), Validators.min(0)]),
    RightV3y: new FormControl('', [Validators.required,Validators.max(60), Validators.min(0)])
  });

  ngOnInit(): void {
  }

   
  change(e) {
    
    if(e.target.value < 0 || e.target.value > 60)
    {
      
      const Toast = Swal.mixin({
        toast: true,
        position: 'top-right',
        iconColor: 'red',
        customClass: {
          popup: 'colored-toast'
        },
        showConfirmButton: false,
        timer: 1500,
        timerProgressBar: true
      })
      Toast.fire({
        icon: 'error',
        title: 'Enter value less than 60'
      })
    }
    
    
  }

  async submit(){
    
    const request = this.form.value;
    await this._data.getLocation(request).then(data =>{
      
      this.location = data
    }).catch(err=>{
      if(err.status == 400 || err.status== 500){
        alert("Please Check the Coordinates");
      }
    });
  }
}
