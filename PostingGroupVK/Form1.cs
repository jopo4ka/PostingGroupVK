using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.RequestParams;

namespace PostingGroupVK
{
    public partial class Form1 : Form
    {
        public VkApi vk = new VkApi();
        public Form1()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text;        // email или телефон
            string pass = textBox2.Text;         // пароль для авторизации
            Settings scope = Settings.All;      // Приложение имеет доступ к друзьям
            vk.Authorize(new ApiAuthParams
            {
                ApplicationId = 6116967,
                Login = email,
                Password = pass,
                Settings = scope
            });
            if (vk.IsAuthorized)
            {
                label3.Text = "AUTHORISED";
            }
            else
            {
                label3.Text = "NONE";
            }
        }

        private void btnSrch_Click(object sender, EventArgs e)
        {
            if (vk.IsAuthorized)
            {
                int cnt = 0;
                int totalCnt;
                var groups = vk.Groups.Search(out totalCnt, new GroupsSearchParams{ Query = txtSrch.Text, Count=100 });
                foreach (var group in groups)
                {
                    var getted = vk.Groups.GetById(group.Id, GroupsFields.CanPost | GroupsFields.CanSeelAllPosts | GroupsFields.MembersCount);
                    bool canPost = getted.CanPost;
                    bool pblcGrp = getted.CanSeelAllPosts;
                    bool valid;
                    if (getted.MembersCount > membersCnt.Value){ valid = true; }
                                              else { valid = false; }
                    if (canPost && pblcGrp && valid)
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[cnt].Cells[0].Value = group.Name;
                        dataGridView1.Rows[cnt].Cells[1].Value = canPost;
                        dataGridView1.Rows[cnt].Cells[2].Value = group.Id;
                        try
                        {
                            PhotoGetAlbumsParams pgap = new PhotoGetAlbumsParams
                            {
                                OwnerId = 0 - group.Id,

                            };
                            var albums = vk.Photo.GetAlbums(pgap);
                            int albCnt = 0;
                            foreach (var album in albums)
                            {
                                DataGridViewTextBoxColumn secondColumn = new DataGridViewTextBoxColumn();
                                secondColumn.HeaderText = "Name " + albCnt;
                                secondColumn.Name = albCnt.ToString();
                                if (dataGridView1.ColumnCount <= albCnt + 3)
                                {
                                    dataGridView1.Columns.Add(secondColumn);
                                }
                                dataGridView1.Rows[cnt].Cells[albCnt + 3].Value = album.Id;  //.Value = album.Id;
                                albCnt++;
                            }
                        }
                        catch 
                        {
                            Debugger.Log(1, "Exception", "Exception");
                        }
                        finally {
                            cnt++;
                        }
                        
                    }
                }
            }
        }

        private void btnSnd_Click(object sender, EventArgs e)
        {
            string[] rf = new string[4];
            var wc = new WebClient();

            if (dataGridView1.ColumnCount > 3)
            {
                for (int row = 0; dataGridView1.RowCount - 1 > row; row++)
                {
                    var groupId = long.Parse(dataGridView1.Rows[row].Cells[2].Value.ToString());
                      
                      var photos = vk.Photo.Get(new PhotoGetParams
                      {
                          Count = 4,
                          AlbumId = PhotoAlbumType.Id(int.Parse(albumID.Text)),
                          OwnerId = vk.UserId
                      });

                    WallPostParams wpp = new WallPostParams
                    {
                        Message = msgWall.Text,
                        OwnerId = 0-groupId,
                        Attachments = photos 
                      };  
                      vk.Wall.Post(wpp);

                    //

                    for (int cel = 3; dataGridView1.ColumnCount - 1 > cel && dataGridView1.Rows[row].Cells[cel].Value != null; cel++)
                    {
                        try { 
                            long albumId = long.Parse(dataGridView1.Rows[row].Cells[cel].Value.ToString());
                            var ups = vk.Photo.GetUploadServer(albumId, groupId);
                            rf[0] = Encoding.ASCII.GetString(wc.UploadFile(ups.UploadUrl, System.Windows.Forms.Application.StartupPath + @"\file1.jpg"));
                            rf[1] = Encoding.ASCII.GetString(wc.UploadFile(ups.UploadUrl, System.Windows.Forms.Application.StartupPath + @"\file2.jpg"));
                            rf[2] = Encoding.ASCII.GetString(wc.UploadFile(ups.UploadUrl, System.Windows.Forms.Application.StartupPath + @"\file3.jpg"));
                            rf[3] = Encoding.ASCII.GetString(wc.UploadFile(ups.UploadUrl, System.Windows.Forms.Application.StartupPath + @"\file4.jpg"));
                            for (int i = 0; i < 4; i++)
                            {
                                var sPhotos = vk.Photo.Save(new PhotoSaveParams
                                {
                                    SaveFileResponse = rf[i],
                                    GroupId = groupId,
                                    AlbumId = albumId
                                });
                            }
                        }   
                        catch
                        {
                            Debugger.Log(1, "Exception", "Exception");
                        }
                    }
                }
               
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DateTime date1 = new DateTime(2917, 10, 7, 7, 00, 00);
            DateTime nowDate = DateTime.Now;
            if (date1 <= nowDate)
            {
                this.Close();
            }
        }
    }
}
