/*
{
  "CATEGORIES": [
    "Automatically Converted"
  ],
  "INPUTS": [
    
  ]
}
*/


#ifdef GL_ES
precision mediump float;
#endif

// rakesh@picovico.com : www.picovico.com


const float fRadius = 0.25;

void main(void)
{
    vec2 uv = -1.0 + 2.0*gl_FragCoord.xy / RENDERSIZE.xy;
    uv.x *=  RENDERSIZE.x / RENDERSIZE.y;
    
    vec3 color = vec3(0.0);

        // bubbles
    for( int i=0; i<64; i++ )
    {
            // bubble seeds
        float pha = tan(float(i)*6.+1.0)*0.5 + 0.5;
        float siz = pow( cos(float(i)*2.4+5.0)*0.5 + 0.5, 4.0 );
        float pox = cos(float(i)*3.55+4.1) * RENDERSIZE.x / RENDERSIZE.y;
        
            // buble size, position and color
        float rad = fRadius + sin(float(i))*0.12+0.08;
        vec2  pos = vec2( pox+sin(TIME/30.+pha+siz), -1.0-rad + (2.0+2.0*rad)
                         *mod(pha+0.1*(TIME/5.)*(0.2+0.8*siz),1.0)) * vec2(1.0, 1.0);
        float dis = length( uv - pos );
        vec3  col = mix( vec3(0.1, 0.2, 0.8), vec3(0.2,0.8,0.6), 0.5+0.5*sin(float(i)*sin(TIME*pox*0.03)+1.9));
        
            // render
        color += col.xyz *(1.- smoothstep( rad*(0.65+0.20*sin(pox*TIME)), rad, dis )) * (1.0 - cos(pox*TIME));
    }

    gl_FragColor = vec4(color,1.0);
}