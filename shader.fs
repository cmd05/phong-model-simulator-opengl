#version 330 core
out vec4 FragColor;

in vec3 FragPos; // interpolated fragment position 
                 
in vec3 Normal; // interpolated normal vector for fragment

uniform vec3 lightPos;
uniform vec3 lightColor;
uniform vec3 objectColor;
uniform vec3 viewPos;

uniform float ambientStrength;
uniform float specularStrength;
uniform float shineValue;
// uniform float diffVal;

void main()
{
    // ambient
    // float ambientStrength = 0.1;
    vec3 ambient = ambientStrength * lightColor;
  	
    // diffuse
    vec3 norm = normalize(Normal.xyz);
    vec3 lightDir = normalize(lightPos - FragPos);
    float diffVal = max(dot(norm, lightDir), 0.0);

    vec3 diffuse = diffVal * lightColor;

    // specular
    vec3 viewDir = normalize(viewPos - FragPos);
    vec3 reflectDir = normalize(reflect(-lightDir, norm)); 

    // float specularStrength = 0.5;
    // float shineValue = 32;
    float spec = pow(max(dot(viewDir, reflectDir), 0.0), shineValue);
    vec3 specular = specularStrength * spec * lightColor;

    vec3 result = (ambient + diffuse + specular) * objectColor;
    FragColor = vec4(result, 1.0);
}